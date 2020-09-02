using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform jenkinsTransform;
    public Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        jenkinsTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraPos = new Vector3(0, 0, -10);
        transform.position = cameraPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        if (jenkinsTransform.position.x > 0)
        {
            temp.x = jenkinsTransform.position.x;
        }
        transform.position = temp; ///

    }
}
