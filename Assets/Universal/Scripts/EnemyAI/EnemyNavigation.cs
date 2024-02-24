using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour
{
    public Transform[] patrolPoints;
    private EnemySight enemySight;
    private NavMeshAgent agent;
    
    private int currentTarget = 0;
    public float navigationUpdateFrequency = 0.15f;
    private bool seenPlayer = false;

    private void Start() 
    {
        enemySight = GetComponent<EnemySight>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Navigate());
    }

    private void Update()
    {
        Vector3 currentTargetPosition = GetCurrentTargetPosition();
        Quaternion targetRotation = Quaternion.LookRotation(currentTargetPosition - transform.position);
        float rotationSpeed =  0.2f;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Navigate()
    {
        while(true)
        {
            if(seenPlayer)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                agent.destination = player.transform.position;
            }

            else
            {
                // Patrol point navigation if there are any
                if(patrolPoints != null)
                {
                    if(agent.remainingDistance <= agent.stoppingDistance)
                    {
                        // Debug.Log(gameObject.name + " reached its destination. going to next destination");
                        currentTarget = GetNextPatrolPointIndex(patrolPoints, currentTarget);
                    }    
                    agent.destination = patrolPoints[currentTarget].position;
                }

                // Check if the AI has noticed the player 
                if(enemySight.isPlayerVisible())
                {
                    // Debug.Log(gameObject.name + " has found the player!");
                    seenPlayer = true;
                }
            }
            yield return new WaitForSeconds(navigationUpdateFrequency);
        }
    }
    
    private int GetNextPatrolPointIndex(Transform[] patrolPointArray, int currentElement)
    {
        if(currentTarget + 1 > patrolPointArray.Length - 1)
        {
            return 0;   // Start back at beginning of array
        }
        else return currentElement + 1;
    }

    private Vector3 GetCurrentTargetPosition()
    {
        if(seenPlayer)
        {
            return GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else
        {
            return patrolPoints[currentTarget].position;
        }
    }

    public bool hasNoticedPlayer()
    {
        return seenPlayer;
    }
}
