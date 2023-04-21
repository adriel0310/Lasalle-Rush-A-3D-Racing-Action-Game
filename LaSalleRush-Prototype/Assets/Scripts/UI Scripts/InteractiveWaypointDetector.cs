using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveWaypointDetector : MonoBehaviour
{
    public GameObject waypointDetectUI; // Reference to the UI object to be shown

    private GameObject detectedObject; // The game object that triggers the UI to be shown

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            detectedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            detectedObject = null;
            waypointDetectUI.SetActive(false); // Hide the UI when the player moves away from the object
        }
    }

    private void Update()
    {
        if (detectedObject != null)
        {
            float distance = Vector3.Distance(transform.position, detectedObject.transform.position);

            if (distance < 20f) // 3 cm in Unity units
            {
                waypointDetectUI.SetActive(true); // Show the UI when the player is close enough to the object
            }
            else
            {
                waypointDetectUI.SetActive(false); // Hide the UI when the player is too far away from the object
            }
        }
    }
}
