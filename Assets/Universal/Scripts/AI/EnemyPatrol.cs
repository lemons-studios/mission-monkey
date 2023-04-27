using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform PatrolEnd1;
    public Transform PatrolEnd2;

    void Start() 
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = PatrolEnd1.position;
    }
}
