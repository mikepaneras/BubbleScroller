using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingObstacle : MonoBehaviour
{
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float patrolSpeed;
    int selectedPatrolPoint = 0;
    [SerializeField] float stoppingDistance = 0.1f;
    [SerializeField] float resumeDelay = 0.5f;
    float currentResumeDelay;
    // Start is called before the first frame update
    void Start()
    {
        currentResumeDelay = resumeDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentResumeDelay > 0)
        {
            currentResumeDelay -= Time.deltaTime;
            return;
        }
        if(transform.position != patrolPoints[selectedPatrolPoint].position)
        {
            Vector3 direction = patrolPoints[selectedPatrolPoint].position - transform.position;
            transform.Translate(direction * Time.deltaTime * patrolSpeed);
            if(Vector3.Distance(transform.position, patrolPoints[selectedPatrolPoint].position) > 0.1f)
            {
                return;
            }
        }
        selectedPatrolPoint++;
        currentResumeDelay = resumeDelay;
        if(selectedPatrolPoint == patrolPoints.Length)
        {
            selectedPatrolPoint = 0;
        }
    }
}
