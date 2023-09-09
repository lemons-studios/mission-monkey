using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : State
{
    public NavMeshAgent agent;
    public Transform[] wayPoints;
    public int currentPoint = 0;
    public bool switchRoute;
    public override State RunCurrentState()
    {

        if(transform.position.x != wayPoints[currentPoint].position.x && transform.position.z != wayPoints[currentPoint].position.z)
        {
            agent.SetDestination(wayPoints[currentPoint].position);
        }
        else
        {
            if(currentPoint !> wayPoints.Length && switchRoute == true)
            {

                currentPoint = currentPoint + 1;

            }
            else if(currentPoint > wayPoints.Length && switchRoute == true)
            {
                switchRoute = false;
            }

            if(currentPoint > wayPoints.Length && switchRoute == false)
            {
                currentPoint = currentPoint - 1;
            }
            else if(currentPoint < 0 && switchRoute == false)
            {
                switchRoute = true;
            }
            
               
        }
        

        return this;
    }
}
