using UnityEngine;
using UnityEngine.AI;

public class AiNavigation : MonoBehaviour
{
    private NavMeshAgent Agent;
    public Vector3[] PatrolLocations;
    private int PatrolCounter;
    private float distanceToDestination, distanceToPlayer;
    public Vector3 PlayerLocation;
    public GameObject PlayerModel, AiModel;

    private void Start()
    {
        PatrolCounter = Mathf.Clamp(PatrolLocations.Length, 0, System.Int32.MaxValue);
        Agent = GetComponent<NavMeshAgent>();
    }
    public void Patrol()
    {
        if (PatrolCounter < PatrolLocations.Length)
        {
            PatrolCounter = 0;
        }
        Agent.SetDestination(PatrolLocations[PatrolCounter]);
    }
    private void FixedUpdate()
    {

    }
}