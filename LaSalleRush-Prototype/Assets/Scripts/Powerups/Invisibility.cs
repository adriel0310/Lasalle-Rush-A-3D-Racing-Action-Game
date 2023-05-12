using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour
{
    NewCarController newCarController;
    Collider playerCollider;
    GameObject[] collidersToIgnore;

    // Start is called before the first frame update
    void Start()
    {
        newCarController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewCarController>();
        // Get the player's collider
        playerCollider = newCarController.GetComponent<Collider>();

        // Get an array of all the colliders with a specific tag    
        collidersToIgnore = GameObject.FindGameObjectsWithTag("Human");
    }

    // Update is called once per frame
    void Update()
    {
        
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

        // Ignore collisions between the player and the colliders with the specific tag
        foreach(GameObject colliderObject in collidersToIgnore) {
            Collider collider = colliderObject.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, collider);
        }

        // Wait for 60 seconds
        yield return new WaitForSeconds(60f);

        // Re-enable collisions between the player and the colliders with the specific tag
        foreach(GameObject colliderObject in collidersToIgnore) {
            Collider collider = colliderObject.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, collider, false);
        }

        // Reset the position and rotation of the powerup
        powerupCollider.transform.position = Vector3.zero;
        powerupCollider.transform.rotation = Quaternion.identity;
    }

}
