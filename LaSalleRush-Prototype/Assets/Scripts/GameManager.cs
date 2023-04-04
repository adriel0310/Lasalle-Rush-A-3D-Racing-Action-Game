using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentCoins;
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI Level;

    [SerializeField] TextMeshProUGUI LevelUI;
    [SerializeField] TextMeshProUGUI Objective;

    [SerializeField] TextMeshProUGUI PickUpPoint;
    [SerializeField] TextMeshProUGUI DropOffPoint;
    public GameObject PickUpPointlbl;
    public GameObject DropOffPointlbl;

    
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
    public GameObject gameoverui;
    
    //For Timer Variables
    public float countdowntimer = 70f;
    public Text TimerText;

    public UnityEvent onTimerCompleted;
    
    //Level Completion Text
    public Text LevelCompleteLRCoins;
    public Text TimeLeft;
    public Text Score;
    public Text TotalScore;
  


    void Start()
    {
        levels[currentlevel - 1].SetActive(true);
        LevelUI.text = "Level " + currentlevel;
        Objective.text = "A student wants to attend mass in Our Lady of the Most Holy Rosary Chapel. You must drop off the student to the location in less than 20 seconds.";
        PickUpPoint.text = "Gate 1 Rotonda";
        currentCoins.text = currentLRCoins +" LR Coins" ;
        currentScore.text = "Score: " + totalScore;
        //currentlevel = 6;
        //currentPassenger = 16;
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
            gameoverui.SetActive(false);
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
        
        // for game over ui screen
        //if(countdowntimer <= 0f)
        //{
        //    Time.timeScale = 0;
        //    onTimerCompleted?.Invoke();
        //    countdowntimer = 0f;
        //}  
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
        Time.timeScale = 0;
        Level.text ="LEVEL " + currentlevel;
        Objective.enabled = false;
        LevelUI.enabled = false;
        PickUpPoint.enabled = false;
        TimerText.enabled = false;
        PickUpPointlbl.SetActive(false);
        DropOffPointlbl.SetActive(false);
        PickUpPoint.enabled = false;
        DropOffPoint.enabled = false;

        LevelCompleteUI.SetActive(true);


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
        Time.timeScale = 1;
        LevelCompleteUI.SetActive(false);
        Objective.enabled = true;
        LevelUI.enabled = true;
        PickUpPoint.enabled = true;
        TimerText.enabled = true;
        PickUpPointlbl.SetActive(true);
        
    }

    public void LevelObjective(){
        switch(currentPassenger){
            case 1:
                Objective.text = "A CSCS professor needs to attend his class in the ICTC building. You must drop off the professor to their desired location.";
                //PickUpPoint.text = "ERS";
                LevelUI.text = "Level 2";
                break;
            case 2:
                Objective.text = "A student is buying school supplies in the National Bookstore and is requesting to wait for him. Once he’s done, drop off the student at the University Square.";
                //PickUpPoint.text = "National Bookstore";
                LevelUI.text = "Level 2";
                break;
            case 3:
                Objective.text = "A student is required to attend a seminar in Severino de las Alas Hall. The seminar starts in less than 30 seconds, you must drop off the student before time runs out.";
                //PickUpPoint.text = "COS building";
                LevelUI.text = "Level 3";
                break;
            case 4:
                Objective.text = "A nurse has to consult a student in Gregoria Montoya Hall. You must drop her off within the time limit.";
                //PickUpPoint.text = "Botanical Garden";
                LevelUI.text = "Level 3";
                break;
            case 5:
                Objective.text = "An Accounting Student needs to pay his tuition fees in the Ayuntamiento building. Drop off the student within the time limit.";
                //PickUpPoint.text = "CBAA building";
                LevelUI.text = "Level 3";
                break;
            case 6:
                Objective.text = "A freshmen student wants to buy some school uniform in the clothing warehouse beside the CBAA building. Drop off the student within the time limit.";
                //PickUpPoint.text = "Gate 1 Rotonda";
                LevelUI.text = "Level 4";
                break;
            case 7:
                Objective.text = "A Tourism student is required to attend PE class in Ugnayang La Salle. Drop off the student within the time limit.";
                //PickUpPoint.text = "CTHM building";
                LevelUI.text = "Level 4";
                break;
            case 8:
                Objective.text = "A freshmen student wants to view preserved items and relics of the university in Museo de La Salle. Drop off the student within the time limit.";
                ///PickUpPoint.text = "Gate 3 Rotonda";
                LevelUI.text = "Level 4";
                break;
            case 9:
                Objective.text = "A PolSci student has been dismissed from his class and wants to leave the campus through Gate 3. Drop off the student within the time limit.";
                //PickUpPoint.text = "JFH building";
                LevelUI.text = "Level 5";
                break;
            case 10:
                Objective.text = "A student finished his swimming class and wants to go to PCH building for his next class. Drop off the student within the time limit.";
                ///PickUpPoint.text = "University pool";
                LevelUI.text = "Level 5" ;
                break;     
            case 11:
                Objective.text = "A CoEd student is required to attend a recollection in RCC. Drop off the student within the time limit.";
                //PickUpPoint.text = "FCH building";
                LevelUI.text = "Level 5";
                break;
            case 12:
                Objective.text = "A student finished his PE class and wants to eat lunch at Mila’s Diner. Drop off the student within the time limit.";
                //PickUpPoint.text = "Ugnayang La Salle";
                LevelUI.text = "Level 5";
                break;
            case 13:
                Objective.text = "A SWAFO Officer is tasked to guard Magpuri Gate (Gate 2). Drop him off within the time limit.";
                //PickUpPoint.text = "Gate 3 Rotonda";
                LevelUI.text = "Level 6";
                break;
            case 14:
                Objective.text = "An NSTP Professor needs to attend his class in the Grandstand. Drop off the professor within the time limit.";
                //PickUpPoint.text = "Mariano Alvarez Hall";
                LevelUI.text = "Level 6";
                break;
            case 15:
                Objective.text = "A varsity player wants to leave the campus through Gate 1. Drop him off within the time limit.";
                //PickUpPoint.text = "Grandstand";
                LevelUI.text = "Level 6";
                break;
            case 16:
                Objective.text = "An incoming freshmen student wants you to take her to a campus tour. You must introduce her to at least 20 buildings.";
                LevelUI.text = "Level 6";
                break;
        }
    }

}
