using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : State
{
    public NavMeshAgent agent;
    public Transform[] wayPoints;
    public int currentPoint = 0;
    public bool switchRoute = true;
    float wait;

    private void Start()
    {
        switchRoute = true;
    }
    public override State RunCurrentState()
    {

        if(transform.position.x != wayPoints[currentPoint].position.x && transform.position.z != wayPoints[currentPoint].position.z)
        {
            agent.SetDestination(wayPoints[currentPoint].position);
           agent.stoppingDistance = 0;
        }
        else
        {
            wait += Time.deltaTime;

            if(currentPoint ==  wayPoints.Length  - 1)
            {
                switchRoute = false;

            }

            if(currentPoint == 0)
            {
                switchRoute = true;
            }
            if (wait > 5)
            {
                if (switchRoute == true)
                {
                    currentPoint = currentPoint + 1;
                    wait = 0;
                }

                if(switchRoute == false)
                {
                    currentPoint = currentPoint - 1;
                    wait = 0;
                }
            }
           
            
               
        }
        

        return this;
    }
}
