using UnityEngine;

public class BallBoundary : MonoBehaviour
{
    public GameManager gameManager;  // Ссылка на GameManager для завершения игры

    void OnTriggerEnter(Collider other)
    {
        // Если объект, коснувшийся границы, имеет тег "Ball", вызываем завершение игры
        if (other.CompareTag("Ball"))
        {
            gameManager.EndGame();  // Завершаем игру через GameManager
        }
    }
}
