using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Invisibility : MonoBehaviour
{
    public TextMeshProUGUI InvisibilityText;
    NewCarController newCarController;
    Collider playerCollider;
    WheelCollider[] PlayerWheels;
    GameObject[] collidersToIgnore;

    float countdown = 60f;

    // Start is called before the first frame update
    void Start()
    {
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        
        // Get the player's collider
        playerCollider = newCarController.GetComponent<Collider>();
        PlayerWheels = newCarController.GetComponentsInChildren<WheelCollider>();

        // Get an array of all the colliders with a specific tag    
        collidersToIgnore = GameObject.FindGameObjectsWithTag("Human");
    }

    // Update is called once per frame
    void Update()
    {
        collidersToIgnore = GameObject.FindGameObjectsWithTag("Human");
    }

    void OnTriggerEnter(Collider other) //Function that get's called when we collide with something
    {
        if(other.CompareTag("Powerup3"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider powerupCollider)
    {
        Debug.Log("Power up picked up!");
        //InvisibilityText.enabled = true;
        //InvisibilityText.text= "Invisibility - " + countdown;

        // Ignore collisions between the player and the colliders with the specific tag
        foreach(GameObject colliderObject in collidersToIgnore) {
            Collider collider = colliderObject.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, collider);
            
            foreach(WheelCollider playerwheels in PlayerWheels){
                Physics.IgnoreCollision(playerwheels, collider);
            }
        }

        // Wait for 60 seconds
        yield return new WaitForSeconds(countdown);

        //InvisibilityText.enabled = false;

        // Re-enable collisions between the player and the colliders with the specific tag
        foreach(GameObject colliderObject in collidersToIgnore) {
            Collider collider = colliderObject.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider , collider, false);

             foreach(WheelCollider playerwheels in PlayerWheels){
                Physics.IgnoreCollision(playerwheels, collider, false);
            }
        }


        // Reset the position and rotation of the powerup
        //powerupCollider.transform.position = Vector3.zero;
        //powerupCollider.transform.rotation = Quaternion.identity;
    }

}
