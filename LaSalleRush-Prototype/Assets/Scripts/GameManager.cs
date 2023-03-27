using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentCoins;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI Level;
    
    //Levels and Passengers
    public int currentlevel;
    public int currentPassenger;

    //Level Completion computation 
    public int remainingTime;
    public int currentLRCoins;
    public int LRCoins_earned;
    public int score;
    public int totalScore;
    public int currentInGameScore;

    //GameObjects
    public GameObject[] levels;
    public GameObject LevelCompleteUI;
    
    //For Timer Variables
    public float countdowntimer = 70f;
    public Text TimerText;
    
    //Level Completion Text
    public Text LevelCompleteLRCoins;
    public Text TimeLeft;
    public Text Score;
    public Text TotalScore;

    void Start()
    {
        levels[currentlevel - 1].SetActive(true);
        currentCoins.text = currentLRCoins +" LR Coins" ;
        currentScore.text = "Score: " + totalScore;
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
    
    //ADD TIME FUNCTIONS
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

    public void AddTime4() // time bonus for level 4
    { 
        countdowntimer += 15f;
        print("Time Added 4");
    }
    public void AddTime5() // time bonus for level 5
    { 
        countdowntimer += 20f;
        print("Time Added 5");
    }
    
    public void AddTime6() // time bonus for level 6
    { 
        countdowntimer += 25f;
        print("Time Added 6");
    }

    //ADD SCORE FUNCTIONS
    public void AddLRCoins1()
    {
        currentLRCoins += 8;
        currentCoins.text = currentLRCoins +" LR Coins";
        LRCoins_earned += 8 ;
    }
    public void AddLRCoins23()
    {
        currentLRCoins += 10;
        currentCoins.text = currentLRCoins +" LR Coins";
        LRCoins_earned += 10;
    }
    public void AddLRCoins4()
    {
        currentLRCoins += 15;
        currentCoins.text = currentLRCoins +" LR Coins";
        LRCoins_earned += 15;
    }
    public void AddLRCoins5()
    {
        currentLRCoins += 20;
        currentCoins.text = currentLRCoins +" LR Coins";
        LRCoins_earned += 20;
    }
    public void AddLRCoins6()
    {
        currentLRCoins += 20;
        currentCoins.text = currentLRCoins +" LR Coins";
        LRCoins_earned += 20;
    }

    public void AddLRCoinsFinalPassenger()
    {
        currentLRCoins += 50;
        currentCoins.text = currentLRCoins +" LR Coins";
        LRCoins_earned += 50;
    }

    
    //UI Functions
    public void LevelComplete()
    {
        Level.text ="LEVEL " + currentlevel;
        LevelCompleteUI.SetActive(true);
        TimerText.enabled = false;

        //Compute and Show Scores in Text UI
        remainingTime = (int)countdowntimer;
        score = 1000;
        totalScore = LRCoins_earned + remainingTime + score;
        currentInGameScore += totalScore;

        LevelCompleteLRCoins.text = LRCoins_earned.ToString();
        TimeLeft.text = remainingTime.ToString();
        Score.text = score.ToString();
        TotalScore.text = totalScore.ToString();
        currentScore.text = "Score: " + currentInGameScore;
        
        //Reset value for next Level Completion
        LRCoins_earned = 0; 


    }
    public void ProceedNextLevel()
    {
        LevelCompleteUI.SetActive(false);
        TimerText.enabled = true;
    }

}
