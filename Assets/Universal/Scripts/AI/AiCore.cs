using UnityEngine;
using UnityEngine.AI;

public class AiCore : MonoBehaviour
{
    public GameObject Player;
    public LayerMask PlayerMask;
    public Vector3 PlayerPos;
    public Transform[] PatrolPoints;
    // public float FovCheck = 0.25f;
    public float FovRange;
    private NavMeshAgent Agent;
    private int DistanceFromPlayer;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        if (Agent == null)
        {
            // Log an error if the navMeshAgent could not be found on any GameObject that has the script attached
            Debug.LogError("NavMeshAgent is not present on " + gameObject.name);
            return;
        }
    }
    private void Update()
    {
        RaycastHit hit;
        // Check if NavMeshAgent is not null and continue the function if so. no more errors!
        if (Agent != null)
        {
            // Round up when converting the distance to the player to an Int
            DistanceFromPlayer = Mathf.CeilToInt(Vector3.Distance(PlayerPos, transform.position));
            if (DistanceFromPlayer >= 5)
            {
                NavigateToPatrolPoints();
            }
            else if (DistanceFromPlayer <= 5 && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, FovRange, PlayerMask))
            {
                NavigateToPlayer();
            }
            else if (DistanceFromPlayer <= 2.5f && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, FovRange, PlayerMask))
            {

            }
        }
        else return;
    }
    private void NavigateToPatrolPoints()
    {
        Debug.Log("Patrolling");
        foreach(Transform i in PatrolPoints) 
        {
            
        }
    }
    private void NavigateToPlayer()
    {

    }
}