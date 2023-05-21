using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    /*[SerializeField] private public Transform target;*/
    /*[SerializeField] private public Transform target2;*/

    public List<GameObject> PickupPoints;
    public List<GameObject> DropoffPoints;
    PickupPoint pickupPoint;

    QuestSystem quest;
    

    void Start()
    {
        pickupPoint = GameObject.FindGameObjectWithTag("Pickup").GetComponent<PickupPoint>();
        quest = GameObject.FindGameObjectWithTag("Pickup").GetComponent<QuestSystem>();
    }

    void Update()
{
    foreach (GameObject PickupPoint in PickupPoints)
    {
        if (PickupPoint.activeSelf)
        {
            // Get the direction from the current position to the PickupPoint
            Vector3 dirToPickupPoint = PickupPoint.transform.position - transform.position;

            // Set the y-component of the direction to zero to avoid pointing down
            dirToPickupPoint.y = 0f;

            // Rotate the arrow to point in the direction of the PickupPoint
            //Quaternion rot = Quaternion.LookRotation(dirToPickupPoint);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(dirToPickupPoint);
        }
    }

    foreach (GameObject DropoffPoint in DropoffPoints)
    {
        if (DropoffPoint.activeSelf)
        {
            // Get the direction from the current position to the DropoffPoint
            Vector3 dirToDropoffPoint = DropoffPoint.transform.position - transform.position;

            // Set the y-component of the direction to zero to avoid pointing down
            dirToDropoffPoint.y = 0f;

            // Rotate the arrow to point in the direction of the DropoffPoint
            //Quaternion rot = Quaternion.LookRotation(dirToDropoffPoint);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(dirToDropoffPoint);
        }
    }
}
        //To check for every active GameObject
        /*Transform activePickupPoint = null;
        Transform activeDropoffPoint = null;

        foreach (Transform point in target)
        {
            if (point.gameObject.activeInHierarchy)
            {
                activePickupPoint = point;
                break;
            }
        }

        foreach (Transform point in target2)
        {
            if (point.gameObject.activeInHierarchy)
            {
                activeDropoffPoint = point;
                break;
            }
        }*/

        //To point if the gameobject is active
        
        /*if(activePickupPoint != null)
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);

            Vector3 dir = (activePickupPoint.position - transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        }

        if(activeDropoffPoint != null)//quest.PlayerIsHere == true)
        {
            Vector3 targetPosition = target2.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
            
            Vector3 dir = (activeDropoffPoint.position - transform.position).normalized;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            
        }*/  
    }
