using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour
{
    public GameObject[] patrolPoints;
    private NavMeshAgent agent;

    public float rotationFrequency = 0.25f;
    public float navigationUpdateFrequency = 0.15f;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private IEnumerator FaceTarget(GameObject target)
    {
        // Shamelessly stealing Quaternion code because I despise math (It pains me to know that I will have to learn 3d math one day)
        while(true)
        {
            Vector3 targetPosition = target.transform.position; 
            targetPosition.y = 0;   // Prevents the ai from getting silly on the Y axis (I think?)
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.2f);    

            yield return new WaitForSeconds(rotationFrequency);
        }
    }
}
