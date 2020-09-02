using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //bool gameIsOver = false;
    public int coinCount = 0;
    public int playerLives = 3;
    public TextMeshProUGUI coinScore;
    public TextMeshProUGUI remainingLives;

    public GameObject gameOverRibbon;


    private void Start()
    {
        Time.timeScale = 1;
        remainingLives.text = playerLives.ToString();
        gameOverRibbon.SetActive(false);
    }

    public void JenkinsDies()
    {
        playerLives--;
        remainingLives.text = playerLives.ToString();
        if (playerLives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over from GameManager");
        gameOverRibbon.SetActive(true);
        Time.timeScale = 0;
        Invoke("Restart", 5f);  ///or load the title screen ... this doesn't seem to be working

    }


    void Restart()
    {
        Debug.Log("restart from game manager");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ScoreCoin(int points)
    {
        coinCount = coinCount + points;
        coinScore.text = coinCount.ToString();
    }




}
