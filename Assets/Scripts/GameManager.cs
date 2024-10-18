using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas gameOverCanvas;  // Ссылка на Canvas, который нужно показать при завершении игры
    private bool gameOver = false;  // Флаг завершения игры

    void Start()
    {
        // Скрываем Canvas в начале игры
        gameOverCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // Если игра завершена и нажата клавиша R, перезапускаем сцену
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void EndGame()
    {
        // Показываем Canvas при завершении игры
        gameOverCanvas.gameObject.SetActive(true);
        gameOver = true;
        Debug.Log("Game Over! Press R to Restart");
    }

    void RestartGame()
    {
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
