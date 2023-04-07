using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<GameObject> Waypoints;
    private bool canInteract = false;

    public string Waypointid;

    GameObject waypointinteractUI = null; //empty initial value for storing

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
            }
        }

   }
    
}
