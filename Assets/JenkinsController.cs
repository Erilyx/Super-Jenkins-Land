﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class JenkinsController : MonoBehaviour
{
    private Rigidbody2D jenkinsRigidBody2D;
    public GameManager gameManager;
    public LevelLoader levelLoader;

    [Header("Default Movement")]
    public float scrollSpeed = 4f;
    public float linearDrag = 4f;
    public LayerMask groundLayer;
    public bool onGround;
    public bool onRightWall = false;
    public bool onLeftWall = false;
    public float distanceToGround = 0.7f;
    public Vector3 colliderOffest;
    public Vector3 colliderWallOffset;
    private float distanceToWall = 0.7f;
    public Vector3 spawnPoint;
    public float gravity = 1f;
    public float fallMultiplier = 5f;
    public bool keepMoving = true;
    public bool isAlive = true;

    [Header("Jump Abilities")]
    public float jumpPowerX = 1f;
    public float jumpPowerY = 15f;
    private bool canJump = true;
    public bool allowScrolling = false;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    public AudioSource jumpSound;
    public AudioSource coinCollect;
    public AudioSource jenkinsDeath;
    public AudioSource starCollect;
    public AudioSource killGoomba;
    public AudioSource bigCoin;
    public AudioSource levelOver;

    // Start is called before the first frame update
    void Start()
    {
        jenkinsRigidBody2D = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        spawnPoint = new Vector3(0, 0, 0);  //need to convert to world coords???

    }

    // Update is called once per frame
    void Update()
    {
        onGround = (Physics2D.Raycast(transform.position + colliderOffest, Vector2.down, distanceToGround, groundLayer) ||
                    Physics2D.Raycast(transform.position - colliderOffest, Vector2.down, distanceToGround, groundLayer));
        onRightWall = (Physics2D.Raycast(transform.position + colliderWallOffset, Vector2.right, distanceToWall, groundLayer) ||
                      Physics2D.Raycast(transform.position - colliderWallOffset, Vector2.right, distanceToWall, groundLayer));
        onLeftWall = (Physics2D.Raycast(transform.position + colliderWallOffset, Vector2.left, distanceToWall, groundLayer) ||
                        Physics2D.Raycast(transform.position - colliderWallOffset, Vector2.left, distanceToWall, groundLayer));

        if (!onRightWall && allowScrolling && keepMoving) 
        { 
            ScrollJenkins();
        }

        ModifyPhysics();  

        // jump
        if (Input.GetKey(KeyCode.X) && canJump)
        {
            jumpTimer = Time.time + jumpDelay;
            canJump = false;
        }


        if (Input.GetKeyUp(KeyCode.X))
        {
            canJump = true;
        }

        if (onGround)
        {
            allowScrolling = true;
        }

        if (Input.GetKey(KeyCode.Return) && GameManager.isGameOver)
        {
            levelLoader.RestartFromBeginning();
        }

    }//end of Update

    private void FixedUpdate()
    {
        if (jumpTimer > Time.time)
        {
            Jump();
        }
    }//end of Fixed Update


    void ScrollJenkins()
    {
             jenkinsRigidBody2D.velocity = new Vector2(scrollSpeed, jenkinsRigidBody2D.velocity.y);
    }

    void Jump()
    {
        JumpSound();
        if (!onGround)
        {
            if (onRightWall)
            {

                jenkinsRigidBody2D.drag = linearDrag * 0.15f; //trying to rejuvinate his spring off the wall
                jenkinsRigidBody2D.velocity = new Vector2(-jumpPowerX, jumpPowerY);
                allowScrolling = false;
            }
            else if (onLeftWall)
            {

                jenkinsRigidBody2D.drag = linearDrag * 0.15f;  //trying to rejuvinate his spring off the wall
                jenkinsRigidBody2D.velocity = new Vector2(jumpPowerX, jumpPowerY);
            }
        }
        else
        {
            jenkinsRigidBody2D.velocity = new Vector2(jenkinsRigidBody2D.velocity.x, jumpPowerY);
        }

        jumpTimer = 0;
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }

    void ModifyPhysics()
    {

        if (onGround)
        {
            jenkinsRigidBody2D.gravityScale = 0.1f;  //what is the gravity when Jenkins is on the ground?
        }
        else
        {
            jenkinsRigidBody2D.gravityScale = gravity;
            jenkinsRigidBody2D.drag = linearDrag * 0.15f;
            if(jenkinsRigidBody2D.velocity.y < 0)  //if is coming down
            {
                if (onRightWall || onLeftWall)
                {
                    jenkinsRigidBody2D.gravityScale = gravity * 1.1f; //lets him  cling to the wall a bit...
                    jenkinsRigidBody2D.drag = 4; //he keeps pushing away from the wall in wall jump hangs....
                }
                else
                {
                    jenkinsRigidBody2D.gravityScale = gravity * fallMultiplier;
                }
            }
            else if((jenkinsRigidBody2D.velocity.y > 0) && !Input.GetKey(KeyCode.X))
            {
                jenkinsRigidBody2D.gravityScale = gravity * (fallMultiplier / 2);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCollect.Play();
            Destroy(other.gameObject);
            gameManager.ScoreCoin(1);
        }


        if (other.gameObject.CompareTag("Enemy"))
        {
            killGoomba.Play();
            jenkinsRigidBody2D.velocity = new Vector2(jenkinsRigidBody2D.velocity.x, jumpPowerY * 1.1f);
        }

        if(other.gameObject.CompareTag("Star"))
        {
            starCollect.Play();
            Destroy(other.gameObject);
            gameManager.StarCollected();
        }

        if (other.gameObject.CompareTag("Lava"))
        {
            jenkinsDeath.Play();
            gameManager.JenkinsDies();
            Invoke("RespawnJenkins", 2);
        }

        if(other.gameObject.CompareTag("EndDoor"))
        {
            keepMoving = false;  ///stop him from scrolling
            jenkinsRigidBody2D.velocity = new Vector2(0,0);
            levelOver.Play();
            StartCoroutine(LevelComplete());
        }

    }

    IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2);
        levelLoader.LoadNextLevel();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Lava") && isAlive)
        {
            gameManager.JenkinsDies();
            isAlive = false;
            jenkinsDeath.Play();
            //stop getting multi-killed by goombas!

            Invoke("RespawnJenkins", 2);
        }

        if (other.gameObject.CompareTag("QuestionBox"))
        {
            bigCoin.Play();
        }

    }

    public void RespawnJenkins()
    {
        Debug.Log("am now in the invoked respawn function");
        transform.position = spawnPoint;
        isAlive = true;

    }

}
