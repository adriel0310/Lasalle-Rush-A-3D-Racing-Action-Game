using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Levels
    public int currentlevel;
    public int currentPassenger;
    public GameObject[] levels;
    //For Timer Variables
    public float countdowntimer = 70f;
    public Text TimerText;

    void Start()
    {
        levels[currentlevel - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();//Timer
        levels[currentlevel - 1].SetActive(true);
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

        TimerText.text = string.Format("{0:00}:{1:00} s",minutes,seconds);
        
        if(countdowntimer < 60f)
        {
            TimerText.text = string.Format("{1:00} s",minutes,seconds);
        }  
    }

    public void AddTime1() // time bonus for level 1 
    {
        countdowntimer += 5f;
        print("Time Added 1");
    }

    public void AddTime23() // time bonus for level 2 & 3
    {
        countdowntimer += 10f;
        print("Time Added 2");
    }

}
