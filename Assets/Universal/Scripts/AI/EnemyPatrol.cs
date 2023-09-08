using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : State
{
    public NavMeshAgent agent;
    public override State RunCurrentState()
    {
       

        return this;
    }
}
