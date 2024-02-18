using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject navigateToPoint;

    public EnemySight enemySight;
    public EnemyAttackBase attackModule;
    
    public float destinationUpdateFrequency = 0.25f;
    public float rotationTowardsTargetDelay = 0.15f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator NavigateToPlayer(GameObject player)
    {
        while (true)
        {
            agent.destination = player.transform.position;
            yield return new WaitForSeconds(destinationUpdateFrequency);
        }
    }

    private IEnumerator FaceTowardsTarget(GameObject target)
    {
        // Once again "borrowing" code from people that actually know how to do this stuff
        // The Vector3 gets thrown through a lot of complicated math to be turned into a rotation coordinate
        while (true)
        {
            Vector3 targetPosition = navigateToPoint.transform.position - transform.position;
            targetPosition.y = 0;
            Quaternion targetPosRotation = Quaternion.LookRotation(targetPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetPosRotation, 0.2f);

            yield return new WaitForSeconds(rotationTowardsTargetDelay);
        }

    }

    public void SetNewDestination(GameObject newDestination)
    {
        navigateToPoint = newDestination;
    }
}
