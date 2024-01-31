using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject navigateToPoint;
    public float destinationUpdateFrequency = 0.25f;

    // [Tooltip("Controls how fast the AI looks towards the player. Set it to a higher value if you prefer more \"human-like\" movement")]
    public float rotationTowardsTargetDelay = 0.15f;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(UpdateAgentDestination());
        StartCoroutine(FaceTowardsTarget());
    }

    private IEnumerator UpdateAgentDestination()
    {
        while(true)
        {
            agent.destination = navigateToPoint.transform.position;
            FaceTowardsTarget();
            yield return new WaitForSeconds(destinationUpdateFrequency);
        }
    }

    private IEnumerator FaceTowardsTarget()
    {
        // Once again "borrowing" code from people that actually know how to do this stuff
        // The Vector3 gets thrown through a lot of complicated math to be turned into a rotation coordinate
        while(true)
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

    }
}
