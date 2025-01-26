using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingObstacle : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float patrolSpeed;        
    [SerializeField] float stoppingDistance = 0.1f; 
    [SerializeField] float resumeDelay = 0.5f; 
    float currentResumeDelay;                 

    [Header("Linear Options")]
    [SerializeField] bool isLinear = false;   
    [SerializeField] bool withBacktrack;
    bool backwards = false;
    Vector3 startingPoint;                    
    bool toStarting = false;                  
    int selectedPatrolPoint = 0;              
    AudioSource audioSource;
    [SerializeField] AudioClip noise;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        startingPoint = transform.position;

        
        currentResumeDelay = resumeDelay;
    }

    void FixedUpdate()
    {
        
        if (currentResumeDelay > 0)
        {
            currentResumeDelay -= Time.deltaTime;
            return;
        }
        audioSource.PlayOneShot(noise);
       
        Vector3 target = GetCurrentTarget();

        
        if (Vector3.Distance(transform.position, target) > stoppingDistance)
        {
            Vector3 direction = (target - transform.position).normalized;
            transform.position += direction * patrolSpeed * Time.deltaTime;
            return; 
        }

        
        currentResumeDelay = resumeDelay;

       
        UpdatePatrolState();
    }

    Vector3 GetCurrentTarget()
    {
        if (!isLinear) 
        {
            return patrolPoints[selectedPatrolPoint].position;
        }
        else 
        {
            if (toStarting && !withBacktrack)
            {
                return startingPoint; 
            }
            else
            {
                return patrolPoints[selectedPatrolPoint].position;
            }
        }
    }

    void UpdatePatrolState()
    {
        if (!isLinear) 
        {
            selectedPatrolPoint = (selectedPatrolPoint + 1) % patrolPoints.Length; 
        }
        else 
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
                
                toStarting = false;
            }
            else
            {
               
                selectedPatrolPoint = (selectedPatrolPoint + 1) % patrolPoints.Length;
                toStarting = true;
            }
        }
    }
}
