using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FreezeTimer : MonoBehaviour
{
    public TextMeshProUGUI FreezeTimerText;
    public float multiplier = 1.4f;
    public float duration = 3f; //Duration of PowerUp
    NewCarController newCarController;
    float countdown = 60f;

    public GameManager gameManagerScript;

    void Start(){
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        GameManager gameManagerScript = GetComponent<GameManager>();
    }
   void OnTriggerEnter(Collider other) //Function that get's called when we collide with something
   {
       if(other.CompareTag("Powerup2"))
       {
           StartCoroutine(Pickup(other));
       }
   }

    IEnumerator Pickup(Collider Player)
    {
       Debug.Log("Power up picked up!");

        gameManagerScript.isCountdownEnabled = false; // Pause the game

        //FreezeTimerText.enabled = true;
        //FreezeTimerText.text= "Freeze Timer - " + countdown;
        //wait for seconds
         yield return new WaitForSecondsRealtime(60f);

        gameManagerScript.isCountdownEnabled = true; // Resume the game
        //FreezeTimerText.enabled = false;

   }
}