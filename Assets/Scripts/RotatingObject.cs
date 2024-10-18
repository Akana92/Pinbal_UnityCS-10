using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 100f;  // �������� ��������

    void Update()
    {
        // ������� ������ ������ ��� Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
