using UnityEngine;
using UnityEngine.AI;

public class CarMover : MonoBehaviour
{
    public Transform finalDestination;

    private NavMeshAgent agent;
    private int currentCornerIndex;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        SetNewPath(transform.position);
    }

    private void Update()
    {
        if (currentCornerIndex < agent.path.corners.Length)
        {
            if (Vector3.Distance(transform.position, agent.path.corners[currentCornerIndex]) < agent.stoppingDistance)
            {
                currentCornerIndex++;
                if (currentCornerIndex < agent.path.corners.Length)
                {
                    agent.SetDestination(agent.path.corners[currentCornerIndex]);
                }
                else
                {
                    Debug.Log("Final destination reached!");
                }
            }
        }
    }

    private void SetNewPath(Vector3 targetPosition)
    {
        agent.SetDestination(finalDestination.position);
    }

    public void SetFinalDestination()
    {
        SetNewPath(transform.position);
    }
}
