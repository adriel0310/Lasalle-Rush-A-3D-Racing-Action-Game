using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropoffPoint : MonoBehaviour
{
   public float duration = 1f;
   public bool droppedoff = false;
   public GameObject NBS;
   
   private int points;
   NewCarController newCarController;
   PickupPoint pickupPoint;
   GameManager gameManagerscript;
    void Start()
    {
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        pickupPoint = GameObject.FindGameObjectWithTag("Pickup").GetComponent<PickupPoint>();
        gameManagerscript = GameObject.Find("GameManager").GetComponent<GameManager>();
        //newCarController.carRB = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") ) //& newCarController.carRB.velocity.magnitude < 12f)
        {  
            StartCoroutine(DropoffPassenger(other));  
        }
    }

    IEnumerator DropoffPassenger(Collider Player)
    {
            yield return new WaitForSeconds(duration);
            GameObject.Find("Passenger1").transform.localScale = new Vector3(1.3447f,1.575854f,1.3447f);
            GameObject.Find("Passenger2").transform.localScale = new Vector3(1.3447f,1.575854f,1.3447f);
            //GameObject.FindGameObjectWithTag("Dropoff").transform.localScale = new Vector3(0,0,0);
            Debug.Log("Passenger Dropped-off!");
            droppedoff = true;
            pickupPoint.pickedup = false;
            NBS.SetActive(false);
            
            //Add Points
            points++;
            print("Score " + points);

            //Addtime
            gameManagerscript.AddTime();
            
            if(pickupPoint.pickedup == false)
            {
                GameObject.Find("Passenger1").transform.localScale = new Vector3(1.3447f,1.575854f,1.3447f);
                GameObject.FindGameObjectWithTag("Pickup").transform.localScale = new Vector3(5.542866f,0.078222f,9.404552f);
            } 
    } 

}
