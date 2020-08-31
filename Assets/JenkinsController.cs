using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JenkinsController : MonoBehaviour
{
    private Rigidbody2D jenkinsRigidBody2D;
    
    [Header("Default Movement")]
    public float scrollSpeed = 4f;
    public float linearDrag = 4f;
    public LayerMask groundLayer;
    public bool onGround;
    public bool onRightWall = false;
    public bool onLeftWall = false;
    private float groundLength = 0.7f;

    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Jump Abilities")]
    private float jumpPowerX = 1f;
    public float jumpPowerY = 15f;
    public bool canJump = true;


    // Start is called before the first frame update
    void Start()
    {
        jenkinsRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        onRightWall = Physics2D.Raycast(transform.position, Vector2.right, groundLength, groundLayer);
        onLeftWall = Physics2D.Raycast(transform.position, Vector2.left, groundLength, groundLayer);

        ScrollJenkins();
        

        ModifyPhysics();  

        // jump
        if (Input.GetKey(KeyCode.X) && onGround && canJump)
        {
            Jump();
            canJump = false;
        }


        if (Input.GetKeyUp(KeyCode.X))
        {
            canJump = true;
        }
    }//end of Update

    private void FixedUpdate()
    {

    }//end of Fixed Update


    void ScrollJenkins()
    {
        if (!onRightWall && !onLeftWall)
        {
             jenkinsRigidBody2D.velocity = new Vector2(scrollSpeed, jenkinsRigidBody2D.velocity.y);
        }
    }

    void Jump()
    {
        Debug.Log("is in the jump function");
        jenkinsRigidBody2D.velocity = new Vector2(jenkinsRigidBody2D.velocity.x, jumpPowerY);

    }

    void ModifyPhysics()
    {

        if (onGround)
        {
            jenkinsRigidBody2D.gravityScale = 0;
        }
        else
        {
            jenkinsRigidBody2D.gravityScale = gravity;
            jenkinsRigidBody2D.drag = linearDrag * 0.15f;
            if(jenkinsRigidBody2D.velocity.y < 0)  //if is coming down
            {
                jenkinsRigidBody2D.gravityScale = gravity * fallMultiplier;
            }
            else if((jenkinsRigidBody2D.velocity.y > 0) && !Input.GetKey(KeyCode.X))
            {
                jenkinsRigidBody2D.gravityScale = gravity * (fallMultiplier / 2);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * groundLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * groundLength);
    }
}
