using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameIsOver = false;
    public void GameOver()
    {
        if (!gameIsOver)
        {
            gameIsOver = true;
            Debug.Log("Game Over from GameManager");
            Invoke("Restart", 1f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
