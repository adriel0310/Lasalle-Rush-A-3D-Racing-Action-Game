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

    public int currentTutorialIndex = 0;
    private bool exitTutorial = false;

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

        tutorialPick.SetActive(true);
    }

    private void Update()
    {
        //Debug.Log(tutorialscreen.activeSelf);
        // Check for input during the tutorial
        if (currentTutorialIndex < tutorial.Length && !exitTutorial && tutorialscreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ProceedToNextTutorial();
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                ExitTutorial();
                exitImage.SetActive(false);
            }
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
        Time.timeScale = 1;

        if (tutorialButton.activeSelf)
        {
            currentTutorialIndex = 0; // Reset the currentTutorialIndex to 0
            Debug.Log(tutorial.Length);
            StartCoroutine(ShowNextTutorial());
        }
    }

    private void ProceedToNextTutorial()
    {
        if (currentTutorialIndex < tutorial.Length - 1)
        {
            tutorial[currentTutorialIndex].SetActive(false);
            continueImage.SetActive(false);

            currentTutorialIndex++;

            tutorial[currentTutorialIndex].SetActive(true);
            continueImage.SetActive(true);
            
            if (currentTutorialIndex == tutorial.Length - 1)
            {
                continueImage.SetActive(false);
                exitImage.SetActive(true);
            }
        }
    }




    private void ExitTutorial()
    {
        if (currentTutorialIndex < tutorial.Length)
        {
            tutorial[currentTutorialIndex].SetActive(false);
            continueImage.SetActive(false);
        }
        ResetArray();
        exitTutorial = true;

        // Return to menu or perform desired action
        Debug.Log("Returning to menu...");

        ExitToMainMenu(camSwitch);
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

        tutorialscreen.SetActive(false);
        camSwitch.SplashScreen();
        Time.timeScale = 0;
        audioManagerScript.ToggleEngineSound(false);
    }



    public void ResetArray()
    {
        // Check if the currentTutorialIndex exceeds the tutorial length
        if (currentTutorialIndex >= tutorial.Length)
        {
            // Reset the currentTutorialIndex to 0
            currentTutorialIndex = 0;
        }
        
        // Activate the first tutorial step
        if (tutorial.Length > 0)
        {
            tutorial[0].SetActive(true);
            continueImage.SetActive(true);

            if (tutorial.Length == 1)
            {
                exitImage.SetActive(true);
            }
        }
    }

}