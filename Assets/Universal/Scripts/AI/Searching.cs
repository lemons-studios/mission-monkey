using System.Collections;
using UnityEngine;

public class Searching : State
{
    public Follow follow;
    public EnemyPatrol enemyPatrol;
    public StateManager stateManager;
    private void Awake()
    {
        stateManager = GetComponentInParent<StateManager>();
    }
    public override State RunCurrentState()
    {
        follow.navMeshAgent.SetDestination(Follow.targetPosition);
        follow.navMeshAgent.stoppingDistance = 0;
        StartCoroutine(nameof(Find));

        return this;
    }

    IEnumerator Find()
    {
        yield return new WaitForSeconds(5);
        stateManager.currentState = enemyPatrol;
        StopCoroutine("Find");

    }
}
