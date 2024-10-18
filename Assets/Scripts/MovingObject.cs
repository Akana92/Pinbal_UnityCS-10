using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 3f;  // �������� ��������
    public float distance = 5f;  // ���������, �� ������� ������ ���������
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;  // ���������� ��������� ������� �������
    }

    void Update()
    {
        // ������� ������ ������-����� �� ������������ ����������
        float movement = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(movement, 0, 0);
    }
}
