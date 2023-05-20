using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FreezeTimer : MonoBehaviour
{
    public TextMeshProUGUI FreezeTimerText;
    public Slider TimerSlider;
    public Image SliderFillImage;
    public float multiplier = 1.4f;
    public int duration = 60; // Duration of PowerUp
    NewCarController newCarController;
    int countdown = 60;

    public GameManager gameManagerScript; // Reference to the GameManager script

    void Start()
    {
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        GameManager gameManagerScript = GetComponent<GameManager>();
        FreezeTimerText.enabled = false;
        TimerSlider.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup2"))
        {
            FreezeTimerText.enabled = true;
            TimerSlider.gameObject.SetActive(true);
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider Player)
    {
        Debug.Log("Power up picked up!");

        gameManagerScript.PauseCountdown(); // Pause the game timer

        // Set up the initial values for the timer and slider
        int timer = countdown;
        TimerSlider.maxValue = countdown;
        TimerSlider.value = countdown;

        // Enable and update the timer text
        FreezeTimerText.enabled = true;

        // Store the original fill amount of the slider
        float originalFillAmount = SliderFillImage.fillAmount;

        while (timer > 0)
        {
            // Update the timer and slider values
            timer -= 1;
            TimerSlider.value = timer;
            FreezeTimerText.text = "FREEZE TIMER!";

            // Update the fill amount of the slider
            SliderFillImage.fillAmount = (float)timer / countdown;

            yield return new WaitForSeconds(1);
        }

        // Freeze the timer at 60 seconds
        TimerSlider.value = countdown;

        gameManagerScript.ResumeCountdown(); // Resume the game timer

        // Disable the timer text and reset the slider
        FreezeTimerText.enabled = false;
        TimerSlider.value = TimerSlider.maxValue;

        // Reset the fill amount of the slider
        SliderFillImage.fillAmount = originalFillAmount;

        FreezeTimerText.enabled = false;
        TimerSlider.gameObject.SetActive(false);
    }
}