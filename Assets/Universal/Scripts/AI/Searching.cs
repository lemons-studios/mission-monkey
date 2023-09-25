using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searching : State
{
    public Follow follow;
    public EnemyPatrol enemyPatrol;
    public override State RunCurrentState()
    {
        follow.navMeshAgent.SetDestination(Follow.targetPosition);
        StartCoroutine("Find");

        return this;
    }

    IEnumerable Find()
    {
        yield return new WaitForSeconds(5);
       yield return enemyPatrol;
        StopCoroutine("Find");

    }
}
