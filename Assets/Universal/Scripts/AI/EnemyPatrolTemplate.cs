// Thanks to Dave / GameDevelopment (YouTube) for creating a tutorial for this
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolTemplate : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, WhatIsPlayer;

    // Patroling Vars
    public Vector3 walkPoint;
    bool walkPointSet;
    public float WalkPointRange;

    //Attack
    public float timeBetweenAttacks;
    bool hasAttacked;

    // State Switching
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        // Check If player is in sight
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrol();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            Chase();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            Attack();
        }
    }
    void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }
    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }
    void Chase()
    {
        agent.SetDestination(player.position);
    }
    void Attack()
    {
        // Stop any movement from the AI
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        if (!hasAttacked)
        {
            // Insert Attack code here

            hasAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }
    private void ResetAttack() {
        hasAttacked = false;
    }
}