using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : State
{
    EnemyEyeSight eyeSight;
    public NavMeshAgent navMeshAgent;
    public PlayerMotor player;


    private void Awake()
    {
        eyeSight  = GetComponentInParent< EnemyEyeSight>();
        player = FindAnyObjectByType<PlayerMotor>();
        navMeshAgent = GetComponentInParent< NavMeshAgent>();   
    }
    public override State RunCurrentState()
    {
        if (eyeSight.seePlayer == true) 
        {
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.stoppingDistance = 5;
        }

        return this;
    }
    
}
