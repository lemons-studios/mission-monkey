// Thanks to "Lofi Dev" for making the tutorial that was used to make this script
// https://www.youtube.com/watch?v=c8Nq19gkNfs

using UnityEngine;
using UnityEngine.AI;

public class AIPathfinding : MonoBehaviour
{
    public bool alwaysUpdateDestination = false;
    public Vector3 target;
    public Transform[] waypoints;
    NavMeshAgent agent;
    FieldOfView fov;
    int waypointIndex;

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
        }
        UpdateDestination();
        fov = GetComponent<FieldOfView>();
        if (
            Vector3.Distance(transform.position, target) > 1
            && Vector3.Distance(transform.position, target) < 10
        )
        {
            agent.speed = 3.5f;
        }
        else
        {
            agent.speed = 0;
        }
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
}
