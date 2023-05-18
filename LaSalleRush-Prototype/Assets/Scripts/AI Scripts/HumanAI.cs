using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class HumanAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator; // Reference to the animator component

    [SerializeField] LayerMask groundLayer;
    [SerializeField] float walkAnimationDuration = 1f; // Duration of the walk animation
    [SerializeField] float destinationCooldown = 5f; // Cooldown period before generating the next destination
    bool walkpointSet;
    float cooldownTimer = 0f; // Timer to track the cooldown period
    float walkAnimationTimer = 0f; // Timer to track the walk animation duration
    Vector3 destPoint;
    Vector3 previousPosition; // Store previous transform position

    [SerializeField] float idleAnimationDuration = 2f; // Duration of the idle animation
    float idleAnimationTimer = 0f; // Timer to track the idle animation duration

    [SerializeField] float rotationSpeed = 10f; // Rotation speed for the character

    private Quaternion targetRotation; // Store the target rotation

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Get the animator component

        // Calculate the walk animation speed based on the walkAnimationDuration
        float walkAnimationSpeed = agent.speed / walkAnimationDuration;
        agent.speed = walkAnimationSpeed; // Set the agent's speed to match the desired walk animation speed

        // Adjust the initial rotation based on the original y-rotation
        transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (!walkpointSet && cooldownTimer <= 0f)
        {
            GenerateDestPoint();
            cooldownTimer = destinationCooldown; // Reset the cooldown timer
        }

        if (!walkpointSet)
        {
            // Transition to the idle animation
            animator.SetBool("isMoving", false);
            idleAnimationTimer = idleAnimationDuration; // Reset the idle animation timer
            cooldownTimer -= Time.deltaTime; // Decrease the cooldown timer
            return; // Exit the method, no destination should be set
        }

        agent.SetDestination(destPoint);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance && !agent.hasPath)
        {
            // Reached the destination point
            walkpointSet = false;
            StartCoroutine(TransitionToIdleAnimationWithDelay());
        }

        if (agent.velocity.magnitude > 0)
        {
            // Transition to the walking animation
            animator.SetBool("isMoving", true);
            walkAnimationTimer = agent.remainingDistance / agent.speed; // Set the walk animation timer based on remaining distance and agent speed

            // Reset the idle animation timer
            idleAnimationTimer = idleAnimationDuration;

            // Get the movement direction in local space
            Vector3 movementDirection = transform.InverseTransformDirection(agent.velocity.normalized);

            // Calculate the target rotation based on the movement direction
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;

            // Adjust the target rotation based on the original y-rotation
            targetRotation = Quaternion.Euler(0f, targetAngle + 90f, 0f);

            // Rotate the character towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        else
        {
            // Decrease the idle animation timer
            idleAnimationTimer -= Time.deltaTime;

            // If idle animation timer has reached zero, transition to the idle animation
            if (idleAnimationTimer <= 0f)
            {
                // Transition to the idle animation
                animator.SetBool("isMoving", false);
            }
        }

        if (walkAnimationTimer > 0f)
        {
            walkAnimationTimer -= Time.deltaTime; // Decrease the walk animation timer
        }
        else
        {
            if (!walkpointSet)
            {
                GenerateDestPoint(); // Call GenerateDestPoint() when walk animation is finished and there is no destination set
                cooldownTimer = destinationCooldown; // Start the cooldown period
            }
        }
    }

    IEnumerator TransitionToIdleAnimationWithDelay()
    {
        // Wait for a delay before transitioning to the idle animation
        float delayDuration = 2f; // Adjust the duration as desired
        yield return new WaitForSeconds(delayDuration);

        // Transition to the idle animation
        animator.SetBool("isMoving", false);
    }

    void GenerateDestPoint()
    {
        NavMeshHit hit;
        Vector3 randomPoint;
        if (NavMesh.SamplePosition(transform.position, out hit, Mathf.Infinity, NavMesh.AllAreas))
        {
            randomPoint = hit.position + Random.insideUnitSphere * 100f; // Generate a random point within a sphere of radius 100 units
            NavMesh.SamplePosition(randomPoint, out hit, Mathf.Infinity, NavMesh.AllAreas);
            destPoint = hit.position;
            walkpointSet = true;

            // Log the generated destination point
            Debug.Log("Generated Destination Point: " + destPoint);
        }
    }

}
