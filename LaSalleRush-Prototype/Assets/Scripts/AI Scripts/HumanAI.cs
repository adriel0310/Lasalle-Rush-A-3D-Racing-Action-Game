using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HumanAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator; // Reference to the animator component
    Vector3 destPoint;
    bool walkpointSet;


    [SerializeField] float range;
    [SerializeField] LayerMask groundLayer;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Get the animator component
    }


    void Update()
    {
        animator.SetFloat("Move", agent.velocity.magnitude);
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet)
            SearchForDest();

        if (walkpointSet)
            agent.SetDestination(destPoint);

        if (agent.remainingDistance < 0.1f && !agent.pathPending)
            walkpointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, 100f, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
