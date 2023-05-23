using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Invisibility : MonoBehaviour
{
    public TextMeshProUGUI InvisibilityText;
    public Slider TimerSlider;
    public Image SliderFillImage;
    NewCarController newCarController;
    Collider playerCollider;
    WheelCollider[] PlayerWheels;
    GameObject[] collidersToIgnore;

    int countdown = 60;

    // Start is called before the first frame update
    void Start()
    {
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        GameManager gameManagerScript = GetComponent<GameManager>();

        // Get the player's collider
        playerCollider = newCarController.GetComponent<Collider>();
        PlayerWheels = newCarController.GetComponentsInChildren<WheelCollider>();

        // Get an array of all the colliders with a specific tag    
        collidersToIgnore = GameObject.FindGameObjectsWithTag("AI");

        InvisibilityText.enabled = false;
        TimerSlider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        collidersToIgnore = GameObject.FindGameObjectsWithTag("AI");
    }

    void OnTriggerEnter(Collider other) //Function that get's called when we collide with something
    {
        if(other.CompareTag("Powerup3"))
        {
            InvisibilityText.enabled = true;
            TimerSlider.gameObject.SetActive(true);
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider powerupCollider)
    {
        Debug.Log("Power up picked up!");

        // Set up the initial values for the timer and slider
        int timer = countdown;
        TimerSlider.maxValue = countdown;
        TimerSlider.value = countdown;

        // Enable and update the timer text
        InvisibilityText.enabled = true;

        // Store the original fill amount of the slider
        float originalFillAmount = SliderFillImage.fillAmount;

        // Ignore collisions between the player and the colliders with the specific tag
        foreach (GameObject colliderObject in collidersToIgnore)
        {
            Collider collider = colliderObject.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, collider);

            foreach (WheelCollider playerWheel in PlayerWheels)
            {
                Physics.IgnoreCollision(playerWheel, collider);
            }
        }

        while (timer > 0)
        {
            // Update the timer and slider values
            timer -= 1;
            TimerSlider.value = timer;
            InvisibilityText.text = "INVISIBILITY";

            // Update the fill amount of the slider
            SliderFillImage.fillAmount = (float)timer / countdown;

            yield return new WaitForSeconds(1);
        }

        // Disable the timer text
        InvisibilityText.enabled = false;
        TimerSlider.value = TimerSlider.maxValue;

        // Reset the fill amount of the slider
        SliderFillImage.fillAmount = originalFillAmount;

        TimerSlider.gameObject.SetActive(false);

        // Re-enable collisions between the player and the colliders with the specific tag
        foreach (GameObject colliderObject in collidersToIgnore)
        {
            Collider collider = colliderObject.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, collider, false);

            foreach (WheelCollider playerWheel in PlayerWheels)
            {
                Physics.IgnoreCollision(playerWheel, collider, false);
            }
        }
    }


}
