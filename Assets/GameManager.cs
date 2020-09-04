using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public int coinCount;
    public int playerLives;
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
        playerLives = PlayerPrefs.GetInt("PlayerLives");
        coinCount = PlayerPrefs.GetInt("coinScore");

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
        PlayerPrefs.SetInt("PlayerLives", playerLives);
        if (playerLives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
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


    public void ScoreCoin(int points)
    {
        coinCount = coinCount + points;
        coinScore.text = coinCount.ToString();
        PlayerPrefs.SetInt("coinScore", coinCount);
    }




}
