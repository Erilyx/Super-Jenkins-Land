using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform jenkinsTransform;

    // Start is called before the first frame update
    void Start()
    {
        jenkinsTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = jenkinsTransform.position.x;
        if(temp.x > 0)
        {
            transform.position = temp;
        }
 
    }
}
