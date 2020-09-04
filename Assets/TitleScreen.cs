using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TitleScreen : MonoBehaviour
{
    public GameObject blinkerCanvas;
    public LevelLoader levelLoader;
    public AudioSource gameStart;
    private float timeHolder = 0;
    //public int playerLives = 3;
    //public int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PlayerLives", 3);
        PlayerPrefs.SetInt("coinScore", 0);
        blinkerCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameStart.Play();
            blinkerCanvas.SetActive(true);
            timeHolder = Time.time + 0.5f;

            Invoke("ContinueGame", 2);
        }
        if (Time.time > timeHolder)
        {
            blinkerCanvas.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        levelLoader.LoadNextLevel();
        Debug.Log("load game");   //level loader

    }

}
