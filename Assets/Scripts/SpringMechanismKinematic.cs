using UnityEngine;

public class SpringMechanism : MonoBehaviour
{
    public Transform[] springParts;           // Массив частей пружины
    public float compressionSpeed = 2f;       // Скорость сжатия пружины
    public float expansionSpeed = 5f;         // Скорость разжатия пружины
    public float minDistance = 0.1f;          // Минимальное расстояние между частями пружины
    public float maxCompression = 2f;         // Максимальное сжатие пружины
    public float releaseImpulse = 500f;       // Импульс, применяемый к шарику
    public float maxCompressionTime = 2f;     // Максимальное время сжатия пружины

    private Vector3[] originalPositions;      // Исходные позиции частей пружины
    private float currentCompression = 0f;    // Текущее сжатие пружины
    private float compressionTimer = 0f;      // Таймер удержания клавиши Space
    private bool isCompressing = false;       // Флаг сжатия пружины
    private bool isReleasing = false;         // Флаг разжатия пружины
    private bool hasHitBall = false;          // Флаг применения силы к шарику

    private Rigidbody ballRigidbody;          // Rigidbody шарика

    void Start()
    {
        // Сохраняем исходные позиции частей пружины
        originalPositions = new Vector3[springParts.Length];
        for (int i = 0; i < springParts.Length; i++)
        {
            originalPositions[i] = springParts[i].position;
        }

        // Находим шарик по тегу "Ball"
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody == null)
            {
                Debug.LogWarning("У шарика отсутствует компонент Rigidbody.");
            }
        }
        else
        {
            Debug.LogWarning("Шарик с тегом 'Ball' не найден в сцене.");
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

    // Метод сжатия пружины
    void CompressSpring()
    {
        isCompressing = true;
        isReleasing = false;

        // Увеличиваем таймер удержания клавиши Space
        compressionTimer += Time.deltaTime;

        // Ограничиваем время сжатия
        compressionTimer = Mathf.Min(compressionTimer, maxCompressionTime);

        // Вычисляем текущее сжатие
        currentCompression = Mathf.Min(compressionSpeed * compressionTimer, maxCompression);

        // Перемещаем части пружины
        for (int i = 1; i < springParts.Length; i++)
        {
            Transform currentPart = springParts[i];
            Transform previousPart = springParts[i - 1];

            // Направление к предыдущей части
            Vector3 direction = (previousPart.position - currentPart.position).normalized;

            // Целевая позиция
            Vector3 targetPosition = currentPart.position + direction * currentCompression * Time.deltaTime;

            // Проверка минимального расстояния
            float distance = Vector3.Distance(currentPart.position, previousPart.position);
            if (distance > minDistance)
            {
                currentPart.position = Vector3.MoveTowards(currentPart.position, targetPosition, compressionSpeed * Time.deltaTime);
            }
        }
    }

    // Метод начала разжатия пружины
    void ReleaseSpring()
    {
        isCompressing = false;
        isReleasing = true;
        hasHitBall = false;
    }

    // Метод продолжения разжатия пружины
    void ContinueReleasingSpring()
    {
        bool allPartsAtOriginalPosition = true;

        // Перемещаем все части пружины обратно
        for (int i = 0; i < springParts.Length; i++)
        {
            springParts[i].position = Vector3.MoveTowards(springParts[i].position, originalPositions[i], expansionSpeed * Time.deltaTime);

            if (Vector3.Distance(springParts[i].position, originalPositions[i]) > 0.001f)
            {
                allPartsAtOriginalPosition = false;
            }
        }

        // Применяем силу к шарику, когда последнее звено достигает его
        if (!hasHitBall && ballRigidbody != null)
        {
            float distanceToBall = Vector3.Distance(springParts[springParts.Length - 1].position, ballRigidbody.position);

            // Для отладки
            Debug.Log("Расстояние до шарика: " + distanceToBall);

            // Выберите подходящее значение порога расстояния, например, 0.5f
            if (distanceToBall < 0.5f)
            {
                hasHitBall = true;

                // Вычисляем силу
                float forceMagnitude = releaseImpulse * (compressionTimer / maxCompressionTime);

                // Направление силы
                Vector3 forceDirection = (ballRigidbody.position - springParts[springParts.Length - 1].position).normalized;

                // Применяем силу к шарику
                ballRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

                Debug.Log("Применена сила к шарику: " + forceMagnitude + " в направлении " + forceDirection);
            }
        }

        // Сброс параметров после полного возврата
        if (allPartsAtOriginalPosition)
        {
            isReleasing = false;
            compressionTimer = 0f;
            currentCompression = 0f;
            hasHitBall = false;
        }
    }

    // Метод сброса пружины
    void ResetSpring()
    {
        // Возвращаем части пружины
        for (int i = 0; i < springParts.Length; i++)
        {
            springParts[i].position = Vector3.MoveTowards(springParts[i].position, originalPositions[i], expansionSpeed * Time.deltaTime);
        }
    }
}
