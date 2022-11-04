using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    PickupPoint pickupPoint;
    

    void Start()
    {
        pickupPoint = GameObject.FindGameObjectWithTag("Pickup").GetComponent<PickupPoint>();
    }

    private void Update()
    {
        if(pickupPoint.pickedup == false)
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }

        if(pickupPoint.pickedup == true)
        {
            Vector3 targetPosition = target2.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            
        }
        
    }
}
