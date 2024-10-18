using UnityEngine;

public class BallBoundary : MonoBehaviour
{
    public GameManager gameManager;  // ������ �� GameManager ��� ���������� ����

    void OnTriggerEnter(Collider other)
    {
        // ���� ������, ����������� �������, ����� ��� "Ball", �������� ���������� ����
        if (other.CompareTag("Ball"))
        {
            gameManager.EndGame();  // ��������� ���� ����� GameManager
        }
    }
}
