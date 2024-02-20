using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using LemonStudios.CsExtensions;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour
{
    public List<GameObject> patrolPoints;
    private GameObject currentTarget;
    private GameObject lastKnownPlayerLocation;     // Specifically for the player if they go out of sight of the AI by turning a corner or something
    private NavMeshAgent agent;
    public float rotationFrequency = 0.25f;
    private int currentPatrolIndex = 0;
    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FaceTarget());
        StartCoroutine(stupidPlayerNavigation());
    }

    private IEnumerator stupidPlayerNavigation()
    {
        while(true)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Player");
            agent.destination = currentTarget.transform.position;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void SetCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }

    public void NavigateToPatrolPoint()
    {
        SetCurrentTarget(patrolPoints[currentPatrolIndex]);     // This should re-run each time this method runs in the case that one of the patrol points are moving
        
        agent.destination = currentTarget.transform.position;
        if(agent.remainingDistance == 0) 
        {
            currentPatrolIndex = GetNextPatrolPoint(currentPatrolIndex);
        }
    }
    
    public void NavigateToPlayer()
    {
        SetCurrentTarget(lastKnownPlayerLocation);
        agent.destination = currentTarget.transform.position;
    }

    public IEnumerator FaceTarget()
    {
        // Shamelessly stealing Quaternion code because I despise math (It pains me to know that I will have to learn 3d math one day)
        while(true)
        {
            Vector3 targetPosition = currentTarget.transform.position; 
            targetPosition.y = 0;   // Prevents the ai from getting silly on the Y axis (I think?)
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);    

            yield return new WaitForSeconds(rotationFrequency);
        }
    }


    private int GetNextPatrolPoint(int input)
    {
        int patrolPointListLength = patrolPoints.Count;
        if(input < patrolPointListLength || input > patrolPointListLength) return LemonUtils.GetFirstNonNullEntryOfList(patrolPoints);
        else return input += 1;
    }

}
