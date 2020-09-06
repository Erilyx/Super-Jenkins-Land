using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaisyController : MonoBehaviour
{

    public Rigidbody2D daisyRB;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        daisyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Invoke("DaisyJump", 1.95f);
    }

    // Update is called once per frame
    void Update()
    {
        if(daisyRB.velocity.y < 0)
        {
            animator.Play("daisy_stand");
        }
    }

    public void DaisyJump()
    {
        animator.Play("daisy_jump");
        daisyRB.velocity = new Vector2(0, 20);
    }
}
