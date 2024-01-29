using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform navigateToPoint;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        agent.destination = navigateToPoint.position;
    }
}
