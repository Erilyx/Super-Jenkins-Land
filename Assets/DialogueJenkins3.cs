using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueJenkins3 : MonoBehaviour
{
    public Rigidbody2D jenkinsRB;
    public GameObject heartImage;
    public Vector2 heartLocation;
    public LevelLoader levelLoader;

    void Start()
    {
        jenkinsRB = GetComponent<Rigidbody2D>();
        Instantiate(heartImage, heartLocation, Quaternion.identity);
        Invoke("JenkinsExit", 2);
        
    }
    private void Update()
    {
        if(jenkinsRB.position.x > 10)
        {
            levelLoader.LoadNextLevel();
        }
    }
    public void JenkinsExit()
    {
        jenkinsRB.velocity = new Vector2(28, 0);
    }
}
