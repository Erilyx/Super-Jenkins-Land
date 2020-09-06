using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public int coinCount = 0;
    public int playerLives = 3;
    public TextMeshProUGUI coinScore;
    public TextMeshProUGUI remainingLives;

    public GameObject gameOverRibbon;
    public static bool isGameOver = false;

    private int starCounter = 1;
    public GameObject starCanvas1;
    public GameObject starCanvas2;
    public GameObject starCanvas3;
    public GameObject starCanvas4;
    public GameObject starCanvas5;
    public GameObject stars5;

    public AudioSource fifthStar;
    public AudioSource hundredthCoin;

    private void Start()
    {
        isGameOver = false;
        if(SceneManager.GetActiveScene().buildIndex > 1)
        {
            Debug.Log("calling the player prefs for Lives, Coins");
            playerLives = PlayerPrefs.GetInt("PlayerLives");
            coinCount = PlayerPrefs.GetInt("coinScore");
        }

        remainingLives.text = playerLives.ToString();
        coinScore.text = coinCount.ToString();

        gameOverRibbon.SetActive(false);

        starCanvas1.SetActive(false);
        starCanvas2.SetActive(false);
        starCanvas3.SetActive(false);
        starCanvas4.SetActive(false);
        starCanvas5.SetActive(false);
        stars5.SetActive(false);
    }

    private void Update()
    {
        
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
        gameOverRibbon.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0.1f;
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
            stars5.SetActive(true);
            playerLives++;
            fifthStar.Play();
            Invoke("TurnOff5Star", 1);
        }
    }

    public void TurnOff5Star()
    {
        stars5.SetActive(false);
    }

    public void ScoreCoin(int points)
    {
        coinCount = coinCount + points;
        coinScore.text = coinCount.ToString();

        if (coinCount >= 100)
        {
            playerLives++;
            coinCount = coinCount - 100;
            remainingLives.text = playerLives.ToString();
            coinScore.text = coinCount.ToString();
            hundredthCoin.Play();
        }

    }
}
