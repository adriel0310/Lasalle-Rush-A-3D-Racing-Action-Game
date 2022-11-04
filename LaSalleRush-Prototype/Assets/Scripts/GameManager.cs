using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //For Timer Variables
    float countdowntimer = 70f;
    public Text TimerText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();//Timer
    }

    void Countdown() 
    {
        if(countdowntimer > 0)
        {
            countdowntimer -= Time.deltaTime;
        }
        else
        {
            countdowntimer = 0;
        }
        float minutes = Mathf.FloorToInt(countdowntimer / 60);
        float seconds = Mathf.FloorToInt(countdowntimer % 60);

        TimerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        
        if(countdowntimer < 60f)
        {
            TimerText.text = string.Format("{1:00}",minutes,seconds);
        }   
    }

    
}
