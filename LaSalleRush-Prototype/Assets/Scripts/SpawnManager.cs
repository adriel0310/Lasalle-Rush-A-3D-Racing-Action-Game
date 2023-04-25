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
    
    private int firstPickupIndex = 0;
    int index;

    public void Start()
    {
         foreach (GameObject pickuppoints in PickupPoints)
        {
            pickuppoints.SetActive(false);
        }

        foreach (GameObject dropoffpoints in DropOffPoints)
        {
            dropoffpoints.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FirstLevel()
    {
         foreach (GameObject pickuppoints in PickupPoints)
        {
            pickuppoints.SetActive(false);
        }

        foreach (GameObject dropoffpoints in DropOffPoints)
        {
            dropoffpoints.SetActive(false);
        }

        PickupPoints[0].SetActive(true);
    }

    public void spawnAll()
    {
        foreach (GameObject dropoffpoints in DropOffPoints)
        {
            dropoffpoints.SetActive(true);
        }
    }

    public void despawnAll()
    {
        foreach (GameObject pickuppoints in PickupPoints)
        {
            pickuppoints.SetActive(false);
        }

        foreach (GameObject dropoffpoints in DropOffPoints)
        {
            dropoffpoints.SetActive(false);
        }
    }

    //Save PickupPoints
    public void SavePickupPoint(int index)
    {
         // Save the index of the current pickup point as the first pickup point for the current level
        firstPickupIndex = index;
        PlayerPrefs.SetInt("FirstPickupIndexLevel", firstPickupIndex);
        
    }

    public void LoadPickupPoint()
    {
        firstPickupIndex = PlayerPrefs.GetInt("FirstPickupIndexLevel");
        PickupPoints[firstPickupIndex].SetActive(true);
    }

}
