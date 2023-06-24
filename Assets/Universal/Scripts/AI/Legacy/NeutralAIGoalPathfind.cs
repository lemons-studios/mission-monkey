using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NeutralAIGoalPathfind : MonoBehaviour
{
    public GameObject NeutralAIParent;
    public Transform PathfindingGoal;
    private NavMeshAgent NeutralAI;
    void Start()
    {
        NeutralAI = NeutralAIParent.GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        NeutralAI.destination = PathfindingGoal.position;
        if (HasReachedDestination(NeutralAI))
        {
            Debug.Log("Agent has reached the destination.");
        }
    }
    public bool HasReachedDestination(NavMeshAgent agent, float pathEndThreshold = 10f)
    {
        // Thanks Phind, I am going insane
        // Check if the agent has a path and if the remaining distance is less than or equal to the stopping distance plus the threshold
        if (agent.hasPath && agent.remainingDistance <= agent.stoppingDistance + pathEndThreshold)
        {
            // Check if the agent's velocity is almost zero
            if (Mathf.Abs(agent.velocity.sqrMagnitude) < float.Epsilon)
            {
                return true;
            }
        }

        return false;
    }

}
