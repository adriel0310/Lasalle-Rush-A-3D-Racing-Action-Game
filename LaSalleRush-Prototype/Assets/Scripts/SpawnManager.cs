using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<GameObject> PickupPoints;
    public List<GameObject> DropOffPoints;

    // Start is called before the first frame update
    public ArrayList firstlevel = new ArrayList();

    public GameObject player;
    
    int index;




    void Start()
    {

        foreach (GameObject pickuppoints in PickupPoints)
        {
            pickuppoints.SetActive(false);
        }

        foreach (GameObject dropoffpoints in DropOffPoints)
        {
            dropoffpoints.SetActive(false);
        }
        
        FirstLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FirstLevel()
    {
        PickupPoints[0].SetActive(true);
    }

    public void spawnAll()
    {
        foreach (GameObject dropoffpoints in DropOffPoints)
        {
            dropoffpoints.SetActive(true);
        }
    }

   public void despawn()
   {    
      
       // foreach (GameObject dropoffpoints in DropOffPoints)
       // {
               // if (dropoffpoints != null)
               // {
                  //   dropoffpoints.SetActive(false);
               // }

        //}

        // Check if index is within list range
        if (index >= 0 && index < DropOffPoints.Count) 
        {
            // Destroy the dropoff point at the given index
            DropOffPoints[index].SetActive(false);
            
            // Remove the dropoff point from the list
            DropOffPoints.RemoveAt(index);
        }
        
   }

}
