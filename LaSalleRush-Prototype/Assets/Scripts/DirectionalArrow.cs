using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    PickupPoint pickupPoint;

    QuestSystem quest;
    

    void Start()
    {
        pickupPoint = GameObject.FindGameObjectWithTag("Pickup").GetComponent<PickupPoint>();
        quest = GameObject.FindGameObjectWithTag("Pickup").GetComponent<QuestSystem>();
    }

    private void Update()
    {
        if(quest.PlayerIsHere == false)
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }

        if(quest.PlayerIsHere == true)
        {
            Vector3 targetPosition = target2.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            
        }
        
    }
}
