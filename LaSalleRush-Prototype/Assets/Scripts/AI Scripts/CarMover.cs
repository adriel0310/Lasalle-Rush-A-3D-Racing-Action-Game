using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMover : MonoBehaviour
{
    public List<Transform> waypoints; // List of waypoints for the car to navigate
    public float stoppingDistance = 1f; // The distance at which the car stops near a waypoint

    private NavMeshAgent agent;
    private int currentWaypointIndex;
    private int previousWaypointIndex; // New variable to store the previous waypoint index

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false; // Disable auto braking to ensure the car continues moving between waypoints

        currentWaypointIndex = Random.Range(0, waypoints.Count); // Start at a random waypoint
        SetDestinationToNextWaypoint();
    }

    void Update()
    {
        // Check if the car has reached the current waypoint
        if (!agent.pathPending && agent.remainingDistance <= stoppingDistance)
        {
            SetDestinationToNextWaypoint();
        }
    }

    void SetDestinationToNextWaypoint()
    {
        // Store the current waypoint index as the previous waypoint index
        previousWaypointIndex = currentWaypointIndex;

        // Cycle through the waypoints, excluding the previous waypoint index
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        while (currentWaypointIndex == previousWaypointIndex)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }

        // Set the car's destination to the next waypoint
        Vector3 nextWaypoint = waypoints[currentWaypointIndex].position;
        agent.SetDestination(nextWaypoint);
    }
}
