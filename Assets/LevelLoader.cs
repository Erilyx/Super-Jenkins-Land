using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartFromBeginning()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadNextLevel()
    {
        if((SceneManager.GetActiveScene().buildIndex > 1) && (SceneManager.GetActiveScene().buildIndex < 4))
        {
            Debug.Log("This is the load next level script setting the player count");
            PlayerPrefs.SetInt("PlayerLives", gameManager.playerLives);
            PlayerPrefs.SetInt("coinScore", gameManager.coinCount);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
