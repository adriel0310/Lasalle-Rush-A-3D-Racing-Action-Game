using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPowerUpHandler : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 3f; //Duration of PowerUp
    NewCarController newCarController;
     void Start()
   {
       newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
   }
   void OnTriggerEnter(Collider other) //Function that get's called when we collide with something
   {
       if(other.CompareTag("Powerup1"))
       {
           StartCoroutine(Pickup(other));
       }
   }

    IEnumerator Pickup(Collider Player)
   {
       Debug.Log("Power up picked up!");

       // Cool Effects
       //Instantiate (pickupEffect,transform.position, transform.rotation); // Can be used in later stages of development

       //Apply Effect to Player
       //Player.transform.localScale *= multiplier;
        newCarController.maxSpeed = 50f;
        newCarController.carRB.AddForce(transform.forward * 10000, ForceMode.Impulse); // Use Impulse to see an immediate effect 

        //wait for seconds
        yield return new WaitForSeconds(duration);

        //Reverse the effect on player
        //Player.transform.localScale /= multiplier;
        newCarController.maxSpeed = 40f;
        newCarController.carRB.AddForce(-transform.forward * 200, ForceMode.Acceleration);
        

       //Remove Power Up Object
       //Destroy(gameObject);
   }
}
