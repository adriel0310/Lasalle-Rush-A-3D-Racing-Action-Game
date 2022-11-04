using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPoint : MonoBehaviour
{
   public float duration = 1.5f;
   float speed;
   public bool pickedup = false;
   NewCarController newCarController;
   DropoffPoint dropoffPoint;
    void Start()
    {
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        dropoffPoint = GameObject.FindGameObjectWithTag("Dropoff").GetComponent<DropoffPoint>();
        newCarController.carRB = GetComponent<Rigidbody>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") & newCarController.carRB.velocity.magnitude < 13f)
        {  
            StartCoroutine(PickupPassenger(other));
            dropoffPoint.droppedoff = false;
        }
    }

    IEnumerator PickupPassenger(Collider Player)
    {
            yield return new WaitForSeconds(duration);
            GameObject.Find("Passenger1").transform.localScale = new Vector3(0,0,0);
            GameObject.Find("Passenger2").transform.localScale = new Vector3(0,0,0);
            GameObject.FindGameObjectWithTag("Pickup").transform.localScale = new Vector3(0,0,0);
            Debug.Log("Passenger Picked-Up!");
            pickedup = true; //Indicates that the passenger has been picked up   
            if(dropoffPoint.droppedoff == false)
            {
                dropoffPoint.NBS.SetActive(true);
            }
            //Instantiate(dropoffprefab,new Vector3(224.04f,32.65f,280.71f),Quaternion.identity);
            
            
    } 
}
