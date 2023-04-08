using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> Waypoints;
    public List<GameObject> waypointUI;
    
    private bool canInteract = false;

    public string Waypointid;

    GameObject waypointinteractUI = null; //empty initial value for storing
    GameObject activeUI;//Empty initial value to check for any active or inactive UI Game Objects

   void OnTriggerEnter(Collider col)
   {
        if(col.CompareTag("Player")) 
        {
            canInteract = true;
 
            foreach (GameObject waypoint in Waypoints)
            {
                if(waypoint.name == Waypointid)
                {
                    waypointinteractUI = waypoint;
                    print(waypointinteractUI);
                    break;
                }
            }

        }

   }
    void OnTriggerExit(Collider col)
   {
        if(col.CompareTag("Player"))
        {
            canInteract = false;
        }
   }

   void Update()
   {
        if(canInteract && Input.GetKeyDown(KeyCode.F))
        {
            if(waypointinteractUI != null)
            {
                print("VROOM VROOM SKKRRT SKKRRT INTERACTED WITH DA WAYPOINT FR FR " + waypointinteractUI);
                
                foreach (GameObject UI in waypointUI)
                {
                    if(UI.name == Waypointid)
                    {
                        waypointinteractUI = UI;
                        print(UI + "UI TO BE SET");
                        UI.SetActive(true);
                        Time.timeScale = 0f;
                        break;
                    }
                }  

            }
        }
   }
   public void ExitWaypointUI()
   {
        foreach (GameObject UI in waypointUI)
        {
            UI.SetActive(false);
            Time.timeScale = 1f;
        }
        
   }
    
}
