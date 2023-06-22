using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NeutralAIGoalPathfind : MonoBehaviour
{
    public GameObject NeutralAIParent;
    public Transform PathfindingGoal;
    void Start()
    {
        NavMeshAgent NeutralAI = NeutralAIParent.GetComponent<NavMeshAgent>();
        NeutralAI.destination = PathfindingGoal.position;
    }
}
