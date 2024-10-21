using UnityEngine;

public class SpringMechanism : MonoBehaviour
{
    public Transform[] springParts;           // ������ ������ �������
    public float compressionSpeed = 2f;       // �������� ������ �������
    public float expansionSpeed = 5f;         // �������� �������� �������
    public float minDistance = 0.1f;          // ����������� ���������� ����� ������� �������
    public float maxCompression = 2f;         // ������������ ������ �������
    public float releaseImpulse = 500f;       // �������, ����������� � ������
    public float maxCompressionTime = 2f;     // ������������ ����� ������ �������

    private Vector3[] originalPositions;      // �������� ������� ������ �������
    private float currentCompression = 0f;    // ������� ������ �������
    private float compressionTimer = 0f;      // ������ ��������� ������� Space
    private bool isCompressing = false;       // ���� ������ �������
    private bool isReleasing = false;         // ���� �������� �������
    private bool hasHitBall = false;          // ���� ���������� ���� � ������

    private Rigidbody ballRigidbody;          // Rigidbody ������

    void Start()
    {
        // ��������� �������� ������� ������ �������
        originalPositions = new Vector3[springParts.Length];
        for (int i = 0; i < springParts.Length; i++)
        {
            originalPositions[i] = springParts[i].position;
        }

        // ������� ����� �� ���� "Ball"
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody == null)
            {
                Debug.LogWarning("� ������ ����������� ��������� Rigidbody.");
            }
        }
        else
        {
            Debug.LogWarning("����� � ����� 'Ball' �� ������ � �����.");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CompressSpring();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ReleaseSpring();
        }
        else if (isReleasing)
        {
            ContinueReleasingSpring();
        }
        else
        {
            ResetSpring();
        }
    }

    // ����� ������ �������
    void CompressSpring()
    {
        isCompressing = true;
        isReleasing = false;

        // ����������� ������ ��������� ������� Space
        compressionTimer += Time.deltaTime;

        // ������������ ����� ������
        compressionTimer = Mathf.Min(compressionTimer, maxCompressionTime);

        // ��������� ������� ������
        currentCompression = Mathf.Min(compressionSpeed * compressionTimer, maxCompression);

        // ���������� ����� �������
        for (int i = 1; i < springParts.Length; i++)
        {
            Transform currentPart = springParts[i];
            Transform previousPart = springParts[i - 1];

            // ����������� � ���������� �����
            Vector3 direction = (previousPart.position - currentPart.position).normalized;

            // ������� �������
            Vector3 targetPosition = currentPart.position + direction * currentCompression * Time.deltaTime;

            // �������� ������������ ����������
            float distance = Vector3.Distance(currentPart.position, previousPart.position);
            if (distance > minDistance)
            {
                currentPart.position = Vector3.MoveTowards(currentPart.position, targetPosition, compressionSpeed * Time.deltaTime);
            }
        }
    }

    // ����� ������ �������� �������
    void ReleaseSpring()
    {
        isCompressing = false;
        isReleasing = true;
        hasHitBall = false;
    }

    // ����� ����������� �������� �������
    void ContinueReleasingSpring()
    {
        bool allPartsAtOriginalPosition = true;

        // ���������� ��� ����� ������� �������
        for (int i = 0; i < springParts.Length; i++)
        {
            springParts[i].position = Vector3.MoveTowards(springParts[i].position, originalPositions[i], expansionSpeed * Time.deltaTime);

            if (Vector3.Distance(springParts[i].position, originalPositions[i]) > 0.001f)
            {
                allPartsAtOriginalPosition = false;
            }
        }

        // ��������� ���� � ������, ����� ��������� ����� ��������� ���
        if (!hasHitBall && ballRigidbody != null)
        {
            float distanceToBall = Vector3.Distance(springParts[springParts.Length - 1].position, ballRigidbody.position);

            // ��� �������
            Debug.Log("���������� �� ������: " + distanceToBall);

            // �������� ���������� �������� ������ ����������, ��������, 0.5f
            if (distanceToBall < 0.5f)
            {
                hasHitBall = true;

                // ��������� ����
                float forceMagnitude = releaseImpulse * (compressionTimer / maxCompressionTime);

                // ����������� ����
                Vector3 forceDirection = (ballRigidbody.position - springParts[springParts.Length - 1].position).normalized;

                // ��������� ���� � ������
                ballRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

                Debug.Log("��������� ���� � ������: " + forceMagnitude + " � ����������� " + forceDirection);
            }
        }

        // ����� ���������� ����� ������� ��������
        if (allPartsAtOriginalPosition)
        {
            isReleasing = false;
            compressionTimer = 0f;
            currentCompression = 0f;
            hasHitBall = false;
        }
    }

    // ����� ������ �������
    void ResetSpring()
    {
        // ���������� ����� �������
        for (int i = 0; i < springParts.Length; i++)
        {
            springParts[i].position = Vector3.MoveTowards(springParts[i].position, originalPositions[i], expansionSpeed * Time.deltaTime);
        }
    }
}
