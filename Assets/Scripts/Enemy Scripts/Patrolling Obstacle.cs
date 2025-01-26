using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingObstacle : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints; // Array of patrol points
    [SerializeField] float patrolSpeed;        // Speed of movement
    [SerializeField] float stoppingDistance = 0.1f; // Distance to stop at each point
    [SerializeField] float resumeDelay = 0.5f; // Delay before resuming patrol
    float currentResumeDelay;                 // Tracks remaining delay time

    [Header("Linear Options")]
    [SerializeField] bool isLinear = false;   // Whether patrol is linear or circular
    [SerializeField] bool withBacktrack;
    bool backwards = false;
    Vector3 startingPoint;                    // The starting position of the object
    bool toStarting = false;                  // Whether the object is returning to the starting position
    int selectedPatrolPoint = 0;              // Index of the current patrol point
    AudioSource audioSource;
    [SerializeField] AudioClip noise;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Save the starting position of the object
        startingPoint = transform.position;

        // Initialize delay timer
        currentResumeDelay = resumeDelay;
    }

    void FixedUpdate()
    {
        // Wait until delay is over
        if (currentResumeDelay > 0)
        {
            currentResumeDelay -= Time.deltaTime;
            return;
        }
        audioSource.PlayOneShot(noise);
        // Determine the current target position
        Vector3 target = GetCurrentTarget();

        // Move towards the target
        if (Vector3.Distance(transform.position, target) > stoppingDistance)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * patrolSpeed * Time.deltaTime;
            return; // Exit if still moving towards the target
        }

        // Once the target is reached, reset the delay
        currentResumeDelay = resumeDelay;

        // Update the patrol logic
        UpdatePatrolState();
    }

    Vector3 GetCurrentTarget()
    {
        if (!isLinear) // Circular patrol
        {
            return patrolPoints[selectedPatrolPoint].position;
        }
        else // Linear patrol
        {
            if (toStarting && !withBacktrack)
            {
                return startingPoint; // Go back to the starting point
            }
            else
            {
                return patrolPoints[selectedPatrolPoint].position; // Go to the current patrol point
            }
        }
    }

    void UpdatePatrolState()
    {
        if (!isLinear) // Circular patrol
        {
            selectedPatrolPoint = (selectedPatrolPoint + 1) % patrolPoints.Length; // Wrap around
        }
        else // Linear patrol
        {
            if(withBacktrack)
            {
                if (!backwards)
                {
                    selectedPatrolPoint++;
                    if(selectedPatrolPoint == patrolPoints.Length - 1)
                    {
                        backwards = true;
                    }
                }
                else
                {
                    selectedPatrolPoint--;
                    if (selectedPatrolPoint == 0)
                    {
                        backwards = false;
                    }
                }
                return;
            }
            if (toStarting)
            {
                // If currently heading to the starting point, toggle `toStarting` to false
                toStarting = false;
            }
            else
            {
                // If at a patrol point, set `toStarting` to true and move to the next patrol point
                selectedPatrolPoint = (selectedPatrolPoint + 1) % patrolPoints.Length;
                toStarting = true;
            }
        }
    }
}
