using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : State
{
    EnemyEyeSight eyeSight;
    public NavMeshAgent navMeshAgent;
    public PlayerMotor player;
    public PlayerHealth playerHealth;


    private void Awake()
    {
        eyeSight = GetComponentInParent<EnemyEyeSight>();
        player = FindAnyObjectByType<PlayerMotor>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }
    public override State RunCurrentState()
    {
       
            navMeshAgent.SetDestination(player.transform.position);
            navMeshAgent.stoppingDistance = 5;

        Attack();

        return this;
    }

    void Attack()
    {
        playerHealth.DamagePlayer(5);
        //shoot stuff
    }
}
