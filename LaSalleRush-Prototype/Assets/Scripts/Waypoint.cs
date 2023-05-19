using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> Waypoints;
    public List<GameObject> waypointUI;

    AudioManager audioManagerScript;
    
    public GameObject waypointDetectUI; // Reference to the UI object to be shown

    private GameObject detectedObject; // The game object that triggers the UI to be shown

    private bool canInteract = false;

    public string Waypointid;

    GameObject waypointinteractUI = null; //empty initial value for storing
    GameObject activeUI;//Empty initial value to check for any active or inactive UI Game Objects


   void Start()
   {
        audioManagerScript = GameObject.Find("AudioManager").GetComponent<AudioManager>();
   }

   void OnTriggerEnter(Collider col)
   {
        if(col.CompareTag("Player")) 
        {
            canInteract = true;
            detectedObject = col.gameObject;
            float distance = Vector3.Distance(transform.position, detectedObject.transform.position);
 
            foreach (GameObject waypoint in Waypoints)
            {
                if (distance < 20f) // 3 cm in Unity units
                {   
                    if(waypoint.name == Waypointid)
                    {
                        waypointDetectUI.SetActive(true);
                        waypointinteractUI = waypoint;
                        print(waypointinteractUI);
                        break;
                    }
                    else
                    {
                    waypointDetectUI.SetActive(false); // Hide the UI when the player is too far away from the object
                    }      
                }
            }
        }

   }
    void OnTriggerExit(Collider col)
   {
        if(col.CompareTag("Player"))
        {
            canInteract = false;
            detectedObject = null;
            waypointDetectUI.SetActive(false);
        }
   }

   void Update()
   {
        if(canInteract && Input.GetKeyDown(KeyCode.F))
        {
            if(waypointinteractUI != null)
            {
                waypointDetectUI.SetActive(false);
                print("VROOM VROOM SKKRRT SKKRRT INTERACTED WITH DA WAYPOINT FR FR " + waypointinteractUI);
                
                foreach (GameObject UI in waypointUI)
                {
                    if(UI.name == Waypointid)
                    {
                        waypointinteractUI = UI;
                        print(UI + "UI TO BE SET");
                        

                        UI.SetActive(true);
                        audioManagerScript.ToggleEngineSound(false);
                        audioManagerScript.SetBackgroundMusicVolume(0.05f); //Between 0-1 only
                        
                        Time.timeScale = 0f;
                        break;
                    }
                }  

            }
        }
   }

   public void ExitWaypointUI()
   {
        //GameObject[] waypointUI = GameObject.FindGameObjectsWithTag("WaypointUI");
        foreach (GameObject UI in waypointUI)
        {
            UI.SetActive(false);
            audioManagerScript.ToggleEngineSound(true);
            audioManagerScript.SetBackgroundMusicVolume(0.5f); //Between 0-1 only
            Time.timeScale = 1f;
        }
        
   }
    
}
