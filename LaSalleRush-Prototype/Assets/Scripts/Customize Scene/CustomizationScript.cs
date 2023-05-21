using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizationScript : MonoBehaviour
{
    public int customizeLRCoins;

    public Button switchButton;  // Reference to the UI button in the Unity Editor
    public GameObject desiredCamera;  // Specify the camera you want to switch to in the Unity Editor
    public GameObject mainCamera;
    public GameObject  SplashScreen;
    public GameObject enableCustomizationPanel;
    public TextMeshProUGUI customizeLRCoinsText;


    AudioManager audioManagerScript;

    public GameObject Car;


    void Start()
    {
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        //switchButton.onClick.AddListener(SwitchToCamera);  // Add a listener to the button click event
    }

    public void SwitchToCamera()
    {
        if (desiredCamera != null || desiredCamera == null )
        {
            audioManagerScript.ToggleEngineSound(false);
            Car.SetActive(true);
            Time.timeScale = 0;
            mainCamera.SetActive(false);// Disable the current camera  
            desiredCamera.SetActive(true);  // Enable the desired camera
            SplashScreen.SetActive(false);
            enableCustomizationPanel.SetActive(true);

            customizeLRCoins = PlayerPrefs.GetInt("CustomizationLRCoins");
            customizeLRCoinsText.text = customizeLRCoins + " LR Coins";
            Debug.Log("customizeLRCoins " + customizeLRCoins);
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
            mainCamera.SetActive(true);/// Disable the current camera  
            desiredCamera.SetActive(false); // Enable the desired camera
            SplashScreen.SetActive(true);
            enableCustomizationPanel.SetActive(false);
        }
    }



}
