using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //For Testing Only
    public float multiplier = 1.4f;
    public float duration = 3f;
    //NewCarController newCarController;

    public ParticleSystem pickupEffect;
   
   void Start()
   {
       //newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
   }
   
   
   void OnTriggerEnter(Collider other) //Function that get's called when we collide with something
   {
       if(other.CompareTag("Player"))
       {
           StartCoroutine( Pickup(other) );
       }
   }

   IEnumerator Pickup(Collider Player)
   {
       Debug.Log("Power up picked up!");

       // Cool Effects
       pickupEffect.Play();
       //Instantiate (pickupEffect,transform.position, transform.rotation);

       //Apply Effect to Player
      //Player.transform.localScale *= multiplier;
       
    

        //Disable Graphics
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //wait for seconds
        yield return new WaitForSeconds(duration);

        //Reverse the effect on player
        //Player.transform.localScale /= multiplier;
     

       //Remove Power Up Object
       Destroy(gameObject);
       
   }
}
