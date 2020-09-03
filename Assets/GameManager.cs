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

    private int starCounter = 1;
    public GameObject starCanvas1;
    public GameObject starCanvas2;
    public GameObject starCanvas3;
    public GameObject starCanvas4;
    public GameObject starCanvas5;

    private void Start()
    {
        Time.timeScale = 1;
        remainingLives.text = playerLives.ToString();
        gameOverRibbon.SetActive(false);

        starCanvas1.SetActive(false);
        starCanvas2.SetActive(false);
        starCanvas3.SetActive(false);
        starCanvas4.SetActive(false);
        starCanvas5.SetActive(false);
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

    public void StarCollected()
    {
        if(starCounter == 1)
        {
            starCanvas1.SetActive(true);
            starCounter++;
        }
        else if (starCounter == 2)
        {
            starCanvas2.SetActive(true);
            starCounter++;
        }
        else if (starCounter == 3)
        {
            starCanvas3.SetActive(true);
            starCounter++;

        }
        else if (starCounter == 4)
        {
            starCanvas4.SetActive(true);
            starCounter++;

        }
        else if (starCounter == 5)
        {
            starCanvas5.SetActive(true);
            starCounter++;
        }

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
