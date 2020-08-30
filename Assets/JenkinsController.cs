using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JenkinsController : MonoBehaviour
{
    private Rigidbody2D jenkins;

    // Start is called before the first frame update
    void Start()
    {
        jenkins = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jenkins.AddForce(Vector2.right, ForceMode2D.Impulse);
        }
    }
}
