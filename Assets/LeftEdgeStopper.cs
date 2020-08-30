using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeftEdgeStopper : MonoBehaviour
{

    public Transform mainCameraTransform;
    public float leftEdgeOffset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = mainCameraTransform.position.x;
        if (temp.x > 0 )
        {
            temp.x = temp.x + leftEdgeOffset;
            transform.position = temp;
        }

    }
}
