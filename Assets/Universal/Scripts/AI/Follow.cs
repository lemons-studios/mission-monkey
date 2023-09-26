using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : State
{
    EnemyEyeSight eyeSight;
    public NavMeshAgent navMeshAgent;
    public PlayerMotor player;
    public PlayerHealth playerHealth;
    public Searching searching;
    public static Vector3 targetPosition;
    bool isSearching = false;

    private void Awake()
    {
        eyeSight  = GetComponentInParent< EnemyEyeSight>();
        player = FindAnyObjectByType<PlayerMotor>();
        navMeshAgent = GetComponentInParent< NavMeshAgent>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    public void Search()
    {
        if (isSearching == false)
        {
            InvokeRepeating("FindPlayer", 1, 1);
        }
    }
    
    
    public override State RunCurrentState()
    {
       
            navMeshAgent.SetDestination(targetPosition);
            navMeshAgent.stoppingDistance = 5;

        if (eyeSight.seePlayer == false)
        {
            CancelInvoke("FindPlayer");
            isSearching = false;
            return searching;

        }

            Attack();

        return this;
    }
    

    void Attack()
    {
        PlayerHealth.Health--;
        //shoot stuff
    }

    void FindPlayer()
    {
        isSearching = true;
        if (eyeSight.seePlayer == true)
        {
            targetPosition = player.transform.position;
        }
        else
        {

        }
    }
}
