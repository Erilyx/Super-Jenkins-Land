using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JenkinsController : MonoBehaviour
{
    private Rigidbody2D jenkinsRigidBody2D;
    
    [Header("Default Movement")]
    public float scrollSpeed = 10f;
    private Vector3 goJenkinsGo = new Vector3(1, 0, 0);
    public float linearDrag = 4f;
    public LayerMask groundLayer;
    public bool onGround;
    public float groundLength = 0.6f;
    public float jumpSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        jenkinsRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);

        if (((Input.GetKeyDown(KeyCode.X)) || (Input.GetKeyDown(KeyCode.Space))) && onGround)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if(onGround)
        {
            ScrollJenkins();
        }
        ModifyPhysics();
    }

    void ScrollJenkins()
    {
        jenkinsRigidBody2D.AddForce(goJenkinsGo, ForceMode2D.Impulse);   //applies a lot of force each time
        if(jenkinsRigidBody2D.velocity.magnitude > scrollSpeed)          //is he going to fast?
        {
            jenkinsRigidBody2D.velocity = Vector3.ClampMagnitude(jenkinsRigidBody2D.velocity, scrollSpeed);  //limits him to scrollSpeed
        }
    }

    void Jump()
    {
        jenkinsRigidBody2D.velocity = new Vector2(jenkinsRigidBody2D.velocity.x, 0);
        jenkinsRigidBody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }
    void ModifyPhysics()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }
}
