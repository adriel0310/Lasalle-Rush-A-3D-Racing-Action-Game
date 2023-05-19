using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Text;
using System.Linq;


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

    [SerializeField] TextMeshProUGUI totalLRcoins;
    [SerializeField] TextMeshProUGUI totalTimeLeft;
    [SerializeField] TextMeshProUGUI totalLevelScore;
    [SerializeField] TextMeshProUGUI pinakaFinalScore;
    [SerializeField] TextMeshProUGUI newScoretxt;
    [SerializeField] TextMeshProUGUI LREarnedtxt;

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

    //Car Positions/Locations
    private Vector3 originalPosition;
    public Quaternion originalRotation;

    private Vector3 savedPosition;
    public Quaternion savedRotation;
    
    //GameObjects
    public GameObject player;
    public GameObject[] levels;
    public GameObject LevelCompleteUI;
    public GameObject gameoverui;
    public GameObject leavegameui;
    public GameObject FinalLevelCompleteUI;
    public GameObject InputNameUI;
    public GameObject GameCompletedUI;
    public GameObject timebonus5;
    public GameObject timebonus10;
    public GameObject timebonus15;
    public GameObject timebonus20;
    
    //For Timer Variables
    public float countdowntimer = 10f;
    
    public float timebonusDuration = 3f;
    public Text TimerText;

    public UnityEvent onTimerCompleted;
    
    //Level Completion Text
    public Text LevelCompleteLRCoins;
    public Text TimeLeft;
    public Text Score;
    public Text TotalScore;

    //For buildingtracking
    public int buildingtracker = 0;
    public int newScore;
    public int LREarned;

    public bool isCountdownEnabled = true;

    public QuestSystem questSystemScript;
    public CamSwitch camSwitch;
    public SpawnManager spawnManagerScript;
    AudioManager audioManagerScript;


    // for scoreboard
    [SerializeField] TextMeshProUGUI scoreText;
    public TextMeshProUGUI allScoresTextComponent;
    public TMP_InputField nameInputField;


    void Start()
    {

        nameInputField.characterLimit = 10;

        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        questSystemScript = GameObject.Find("QuestSystem").GetComponent<QuestSystem>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        CamSwitch camSwitch = GetComponent<CamSwitch>();

        originalRotation = player.transform.rotation;
        originalPosition = player.transform.position;
        levels[currentlevel - 1].SetActive(true);
        LevelUI.text = "Level " + currentlevel;
        Objective.text = "A student wants to attend mass in Our Lady of the Most Holy Rosary Chapel. You must drop off the student to the location in less than 20 seconds.";
        PickUpPoint.text = "Gate 1 Rotonda";
        currentCoins.text = currentLRCoins +" LR Coins" ;
        currentScore.text = "Score: " + totalScore;
        //player.GetComponent<Transform>();
        //currentlevel = 6;
        //currentPassenger = 16;
        newScore = PlayerPrefs.GetInt("NewScore", 0);

        SaveCurrentData();
    }

    // Update is called once per frame
    void Update()
    {

        if (isCountdownEnabled)
        {
            Countdown();
        }

        levels[currentlevel - 1].SetActive(true);
    }

    public void Countdown() 
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
        
        //for game over ui screen
        if (countdowntimer == 0f & !leavegameui.activeSelf) {
            onTimerCompleted?.Invoke();
            Time.timeScale = 0;
            gameoverui.SetActive(true);
        } 
    }

    public void RepeatLevel(){
        //player.transform.rotation = originalRotation;
        //player.transform.position = originalPosition;
        //Reset LR coins and score for that level only
        spawnManagerScript.despawnAll();
        LRCoins_earned = 0;
        Time.timeScale = 1;
        gameoverui.SetActive(false);

        //Load Data from SaveCurrentData() Function
        LoadPreviousData();

    }

    // pag pinindot "No" sa repeat level & exit to main menu sa pause screen
    public void LeaveGame(){
        
        leavegameui.SetActive(true);
        gameoverui.SetActive(false);
    }

    // babalik yung player sa start screen
    public void ExitToMainMenu(CamSwitch camSwitch)
    {
        gameoverui.SetActive(false);
        player.transform.rotation = originalRotation;
        player.transform.position = originalPosition;
        camSwitch.SplashScreen();
        audioManagerScript.ToggleEngineSound(false);

        ResetAllValues();
    }
    public void ResetAllValues()
    {
        currentLRCoins = 0;
        remainingTime = 0;
        totalScore = 0;
        currentInGameScore = 0;
        currentPassenger = 0;
        currentlevel = 1;
        countdowntimer = 300f;
        spawnManagerScript.despawnAll();
    }

    public void SaveCurrentData()
    {
        PlayerPrefs.SetInt("SavedLRCoins", currentLRCoins);
        
        PlayerPrefs.SetInt("SavedGameScore", currentInGameScore);

        PlayerPrefs.SetFloat ("SavedCountdownTime", countdowntimer);

        PlayerPrefs.SetInt("SavedCurrentLevel", currentlevel);

        PlayerPrefs.SetInt("SavedCurrentPassenger", currentPassenger);

        // Save the player's position and rotation
        savedPosition = player.transform.position;
        savedRotation = player.transform.rotation;

        print("SavedPosition " + savedPosition);
        print("SavedRotation " + savedRotation);
        print("SavedLRCoins " + currentLRCoins);
        print("SavedGameScore " + currentInGameScore);
        print("SavedCountdownTime " + countdowntimer);
        print("SavedCurrentLevel " + currentlevel);
        print("SavedCurrentPassenger " + currentPassenger);
    }

    public void LoadPreviousData()
    {
    //Load all Previous Values Saved from SaveCurrentData() function
    currentLRCoins = PlayerPrefs.GetInt("SavedLRCoins");
    
    currentInGameScore = PlayerPrefs.GetInt("SavedGameScore");

    countdowntimer = PlayerPrefs.GetFloat("SavedCountdownTime");

    currentlevel = PlayerPrefs.GetInt("SavedCurrentLevel");

    currentPassenger = PlayerPrefs.GetInt("SavedCurrentPassenger");

     // Load the player's position and rotation
    player.transform.position = savedPosition;
    player.transform.rotation = savedRotation;

    spawnManagerScript.LoadPickupPoint();
    print("CurrentPassenger "+ currentPassenger);

    }
    
    //ADD TIME FUNCTIONS
    public void AddTime1() // time bonus for level 1 
    {
        countdowntimer += 5f;
        StartCoroutine(ActivateAndDeactivateTimeBonus(timebonus5));
        print("Time Added 1");
    }

    public void AddTime23() // time bonus for level 2 & 3
    {
        countdowntimer += 10f;
        StartCoroutine(ActivateAndDeactivateTimeBonus(timebonus10));
        print("Time Added 2");
    }

    public void AddTime4() // time bonus for level 4
    { 
        countdowntimer += 15f;
        StartCoroutine(ActivateAndDeactivateTimeBonus(timebonus15));
        print("Time Added 4");
    }
    public void AddTime5() // time bonus for level 5
    { 
        countdowntimer += 20f;
        StartCoroutine(ActivateAndDeactivateTimeBonus(timebonus20));
        print("Time Added 5");
    }
    
    public void AddTime6() // time bonus for level 6
    { 
        countdowntimer += 15f;
        StartCoroutine(ActivateAndDeactivateTimeBonus(timebonus15));
        print("Time Added 6");
    }

    //DELAY FOR TIME BONUS UI
    private IEnumerator ActivateAndDeactivateTimeBonus(GameObject timebonus)
    {
        timebonus.SetActive(true);
        yield return new WaitForSeconds(timebonusDuration);
        timebonus.SetActive(false);
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
    
    // Add Buildingtracking for Final Level
    public void AddBuildingtracking()
    {
        buildingtracker++;
        print("BOB THE BUILDER TRACKER UWU "+ buildingtracker);

        if(buildingtracker == 20)
        {
            FinalLevelComplete(); 
        }    
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
        //score = 1000;
        totalScore = LRCoins_earned + remainingTime;
        currentInGameScore += totalScore;

        LevelCompleteLRCoins.text = LRCoins_earned.ToString();
        TimeLeft.text = remainingTime.ToString();
        //Score.text = score.ToString();
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
        countdowntimer += 120f;
        //Saving Values using PlayerPrefs
        SaveCurrentData();
        
    }

    public void FinalLevelComplete()
    {
        Objective.enabled = false;
        LevelUI.enabled = false;
        PickUpPoint.enabled = false;
        TimerText.enabled = false;
        PickUpPointlbl.SetActive(false);
        DropOffPointlbl.SetActive(false);
        PickUpPoint.enabled = false;
        DropOffPoint.enabled = false;



        //Compute and Show Scores in Text UI
        remainingTime = (int)countdowntimer;
        //score = 1000;
        totalScore = LRCoins_earned + remainingTime;
        currentInGameScore += totalScore;

        totalLRcoins.text = LRCoins_earned.ToString();
        totalTimeLeft.text = remainingTime.ToString();
        totalLevelScore.text = totalScore.ToString();
        pinakaFinalScore.text = "Score: " + currentInGameScore;

        FinalLevelCompleteUI.SetActive(true);
        Time.timeScale = 0;

    }


    public void NextBtn()
    {
        FinalLevelCompleteUI.SetActive(false);
        InputNameUI.SetActive(true);

        newScore = currentInGameScore;
        LREarned += LRCoins_earned;
        PlayerPrefs.SetInt("NewScore", newScore);

        newScoretxt.text = newScore.ToString();
        LREarnedtxt.text = LREarned.ToString();
        Time.timeScale = 0;
    }

    public void SubmitBtn()
    {
        string playerName = nameInputField.text;

        // Save the new player's score
        PlayerPrefs.SetInt(playerName, newScore);

        InputNameUI.SetActive(false);
        GameCompletedUI.SetActive(true);

        // Display the new player's score
        scoreText.text = $"{playerName}: {newScore}";

        // Display all the previous players and their scores, including the new player's score
        string allScoresText = "";
        var playerScores = PlayerPrefs.GetString("PlayerNames").Split(',')
            .Select(key => new { Name = key, Score = PlayerPrefs.GetInt(key) })
            .Where(ps => ps.Score > 0) // Only include players with a score greater than 0
            .OrderByDescending(ps => ps.Score)
            .Take(10)
            .ToList();

        // Add current player's score to list of player scores
        playerScores.Add(new { Name = playerName, Score = newScore });
        playerScores = playerScores.OrderByDescending(ps => ps.Score).ToList();

        int currentPlayerRank = playerScores.FindIndex(ps => ps.Name == playerName) + 1;

        int rank = 1;
        foreach (var ps in playerScores.Take(10))
        {
            allScoresText += $"{rank}. {ps.Name}   {ps.Score}\n";

            rank++;
        }

        allScoresText = allScoresText.TrimEnd(); // Remove the last newline character
        allScoresTextComponent.text = allScoresText;

        // Display the current player's rank at the bottom
        allScoresTextComponent.text += $"\n\nYour rank: {currentPlayerRank}";

        // Update the list of player names
        string playerNames = PlayerPrefs.GetString("PlayerNames");
        if (!playerNames.Contains(playerName))
        {
            playerNames += playerName + ",";
            PlayerPrefs.SetString("PlayerNames", playerNames);
        }

        Time.timeScale = 0;
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