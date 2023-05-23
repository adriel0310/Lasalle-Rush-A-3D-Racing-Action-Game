//original

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    public GameObject player;

    public GameObject tutorialPick;
    public GameObject tutorialDrop;

    public GameObject tutorialscreen;
    public GameObject[] tutorial;
    private GameObject[] backupTutorial;
    public GameObject continueImage;
    public GameObject exitImage;
    public GameObject tutorialButton;
    public float continueImageDelay = 2f;
    public float exitImageDelay = 3f;

    int currentTutorialIndex = 0;
    public bool exitTutorial = false;

    public bool TutorialComplete = false;

    // Car Positions/Locations
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public CamSwitch camSwitch;
    private AudioManager audioManagerScript;
    


    private void Start()
    {
        camSwitch = GetComponent<CamSwitch>();
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        originalRotation = player.transform.rotation;
        originalPosition = player.transform.position;

        //tutorialPick.SetActive(true);

        //currentTutorialIndex = 0;
    }

    private void Update()
    {
        //Debug.Log(tutorialscreen.activeSelf);
        // Check for input during the tutorial
        if (TutorialComplete == false  /*&& !exitTutorial  /*tutorialscreen.activeSelf*/)
        {
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            ProceedToNextTutorial();
        }

        if(TutorialComplete == true /*&& !exitTutorial  /*tutorialscreen.activeSelf*/)
        {
            ExitTutorial();
        }
        
    }
    

    private void OnTriggerEnter(Collider col)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("pickup");
                if (tutorialPick != null)
                {
                    tutorialPick.SetActive(false);
                    Debug.Log(tutorialButton.activeSelf);
                }
                if (tutorialDrop != null)
                {
                    tutorialDrop.SetActive(true);
                }
            }
        }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (tutorialDrop != null)
            {
                tutorialDrop.SetActive(false);
            }
        }
    }

    public void StartTutorial()
    {

        if (tutorialButton.activeSelf)
        {
            //currentTutorialIndex = 0; // Reset the currentTutorialIndex to 0
            Debug.Log (TutorialComplete);
            StartCoroutine(ShowNextTutorial());
            Time.timeScale = 1;
        }
    }


    private void ProceedToNextTutorial()
    {
        //currentTutorialIndex = 0;
        if( Input.GetKeyDown(KeyCode.E))
        {
            if (TutorialComplete == false)
            {                
                tutorial[currentTutorialIndex].SetActive(false);
                continueImage.SetActive(false);

                currentTutorialIndex ++;
                Debug.Log(currentTutorialIndex);

                tutorial[currentTutorialIndex].SetActive(true);
                continueImage.SetActive(true);
            
                if (currentTutorialIndex == tutorial.Length - 1)
                {
                    continueImage.SetActive(false);
                    exitImage.SetActive(true);
                    TutorialComplete = true;
                    Debug.Log("Tutorial Completed " + TutorialComplete);
                    currentTutorialIndex = 6;
                }
            }
        }
    }


    private void ExitTutorial()
    {
        if (Input.GetKeyDown(KeyCode.Y)){

            if (TutorialComplete == true )
            {
                tutorial[currentTutorialIndex].SetActive(false);
                continueImage.SetActive(false);
                exitImage.SetActive(false);  
                TutorialComplete = false; //Reset boolean
                currentTutorialIndex = 0;
                Debug.Log ("Reverted back to " + TutorialComplete);
            }

            exitTutorial = true;
            // Return to menu or perform desired action
            Debug.Log("Returning to menu...");

            ExitToMainMenu(camSwitch);
        }
    }

    private IEnumerator ShowNextTutorial()
    {
        Debug.Log("next tutorial");
        if (tutorial.Length > 0)
        {
            tutorial[0].SetActive(true);
            continueImage.SetActive(true);

            if (tutorial.Length == 1)
            {
                exitImage.SetActive(true);
            }
        }

        yield return null;
    }

    public void ExitToMainMenu(CamSwitch camSwitch)
    {
        continueImage.SetActive(false);
        exitImage.SetActive(false);
        player.transform.rotation = originalRotation;
        player.transform.position = originalPosition;

        currentTutorialIndex = 0; // Reset the currentTutorialIndex to 0

        camSwitch.tutorialButton.SetActive(true);
        tutorialscreen.SetActive(false);
        tutorialPick.SetActive(false);
        tutorialDrop.SetActive(false);
        camSwitch.SplashScreen();
        Time.timeScale = 0;
        audioManagerScript.ToggleEngineSound(false);

    }

    private void ResetTutorialArray()
    {
        for (int i = 0; i < tutorial.Length; i++)
        {
            tutorial[i].SetActive(false);
        }
    }

    public void AccessTutorialArray()
    {
        for (int i = 0; i < tutorial.Length; i++)
        {
            tutorial[i].SetActive(true);
        }
    }

    



}