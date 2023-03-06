using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<GameObject> PickupPoints;
    public List<GameObject> DropOffPoints;
    // Start is called before the first frame update
    public ArrayList firstlevel = new ArrayList();
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
}
