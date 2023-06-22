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
    }
}
