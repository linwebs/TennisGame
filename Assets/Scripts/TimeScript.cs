using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScript : MonoBehaviour
{
    public Text Gametimer;
    //public Text Boardtimer;

    private float timer_f;
    private int timer_i;

    private int mins;
    private int secs;

    private string mins0;
    private string secs0;

    void Start()
    {
        mins = 0;
        secs = 0;

        mins0 = "0";
        secs0 = "0";
    }

    // Update is called once per frame
    void Update()
    {
        timer_f = Time.time;
        timer_i = Mathf.FloorToInt(timer_f);
        if (timer_i >= 60)
        {
            mins = timer_i / 60;
            secs = timer_i % 60;

            if (mins >= 10)
                mins0 = "";
            else if(mins < 10)
                mins0 = "0";

            if (secs >= 10)
                secs0 = "";
            else if(secs < 10)
                secs0 = "0";
        }
        else
        {
            secs = timer_i;
            if (secs >= 10)
                secs0 = "";
            else if (secs < 10)
                secs0 = "0";
        }

        Gametimer.text = "00:" + mins0 + mins.ToString() + ":" + secs0 + secs.ToString();
    }
}
