
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossman : MonoBehaviour
{
    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    public Vector2 endPosition;
    public Vector2 startPosition;
    public GameObject bossman2;

    private void StartLerping()
    {
        timeStartedLerping = Time.time;
        shouldLerp = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartLerping();
        Invoke("SwitchBosses", 2.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldLerp)
        {
            transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
        }

    }

    public void SwitchBosses()
    {
        Instantiate(bossman2, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
