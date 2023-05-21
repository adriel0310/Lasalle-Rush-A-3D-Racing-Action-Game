using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizationScript : MonoBehaviour
{
    public Button switchButton;  // Reference to the UI button in the Unity Editor
    public Camera desiredCamera;  // Specify the camera you want to switch to in the Unity Editor
    public Camera mainCamera;
    public GameObject  SplashScreen;
    public GameObject enableCustomizationPanel;

    AudioManager audioManagerScript;

    public GameObject Car;


    void Start()
    {
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        //switchButton.onClick.AddListener(SwitchToCamera);  // Add a listener to the button click event
    }

    public void SwitchToCamera()
    {
        if (desiredCamera != null)
        {
            audioManagerScript.ToggleEngineSound(false);
            Car.SetActive(true);
            Time.timeScale = 0;
            mainCamera.enabled = false;// Disable the current camera  
            desiredCamera.enabled = true;  // Enable the desired camera
            SplashScreen.SetActive(false);
            enableCustomizationPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Camera reference is null!");  // Output an error if the camera reference is null
        }
    }

    public void SwitchToMainCamera()
    {
        if (desiredCamera != null)
        {
            audioManagerScript.ToggleEngineSound(false);
            Car.SetActive(false);
            Time.timeScale = 1;
            mainCamera.enabled = true;// Disable the current camera  
            desiredCamera.enabled = false;  // Enable the desired camera
            SplashScreen.SetActive(true);
            enableCustomizationPanel.SetActive(false);
        }
    }
}
