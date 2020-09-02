using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
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

    private void Update()
    {
        
    }

    public void JenkinsDies()
    {
        playerLives--;
        remainingLives.text = playerLives.ToString();
        //Time.timeScale = 0;
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
