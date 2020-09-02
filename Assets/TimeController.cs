using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public int startingTime = 90;
    private float tickTime = 0f;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timeText.text = "TIME " + startingTime.ToString();
        if(Time.time - tickTime >= 1)
        {
            startingTime--;
            tickTime = Time.time;
        }

        if(startingTime == 0)
        {
            Debug.Log("Player Death by time");
        }
    }


}
