using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bounceForce = 1000f;  // ���� ������������

    void OnCollisionEnter(Collision collision)
    {
        // ���������, ��� ������������ ��������� � ��������, � �������� ���� Rigidbody (��������, �����)
        Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (ballRigidbody != null)
        {
            // ������������ ����������� ������������ ��� ����������� �� ������� � ������
            Vector3 bounceDirection = collision.transform.position - transform.position;
            bounceDirection = bounceDirection.normalized;  // ����������� ������, ����� �������� �����������

            // ��������� ���� ������������ � ������
            ballRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
