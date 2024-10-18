using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas gameOverCanvas;  // ������ �� Canvas, ������� ����� �������� ��� ���������� ����
    private bool gameOver = false;  // ���� ���������� ����

    void Start()
    {
        // �������� Canvas � ������ ����
        gameOverCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // ���� ���� ��������� � ������ ������� R, ������������� �����
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void EndGame()
    {
        // ���������� Canvas ��� ���������� ����
        gameOverCanvas.gameObject.SetActive(true);
        gameOver = true;
        Debug.Log("Game Over! Press R to Restart");
    }

    void RestartGame()
    {
        // ������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
