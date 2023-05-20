using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

   void Update()
   {

   }
   
   
   void OnTriggerEnter(Collider other) //Function that get's called when we collide with something
   {
       if(other.CompareTag("Player"))
       {
           //StartCoroutine( Pickup(other) );
           Pickup(other);
       }
   }

   public void Pickup (Collider Player)
   {
       Debug.Log("Power Up Picked up!");

       // Cool Effects
       pickupEffect.Play();
       
       gameObject.SetActive(false);

        //Disable Graphics
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<Collider>().enabled = false;
        //gameObject.SetActive(false);
        //wait for seconds
       
   }
}
