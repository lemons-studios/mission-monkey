using System;
using System.Collections;
using UnityEngine;
public class AiFoV : MonoBehaviour
{
    //public GameObject Ai;
    [Range(0, 130)]
    public float angle;
    public bool canSeePlayer;
    public static bool AiSeePlayer;
    public LayerMask obstructionMask;

    public static GameObject Player;
    public float radius;

    public LayerMask targetMask;

    private Vector3 targetPos;

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask); // Create a list of everything within the spherical range of gameObject
        if (rangeChecks.Length != 0) // Run if at least one object is within range
        {
            Transform target = rangeChecks[0].transform; // The first object in the list is the target (maybe could be improved in the future by iterating through the list)
            Vector3 directionToTarget = (target.position - transform.position).normalized; // Get rotation towards the target in relative to the gameObject's rotation
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2) // If the relative rotation is within the FOV degrees divided by 2 (because the FOV is symmetrical)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position); // Get distance to target
                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)) // Fire a raycast to see if it's possible to shoot the target object
                {
                    targetPos = GetComponent<AiNavigation>().PlayerLocation; // Set the target position to the target object's position
                    if (Vector3.Distance(transform.position, targetPos) < 10) // If distance to target is less than 10, then it is visible
                    {
                        canSeePlayer = true;
                    }
                    else
                    {
                        canSeePlayer = false;
                    }
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    public void FixedUpdate()
    {
        if (canSeePlayer == true)
        {
            AiSeePlayer = true;
        }
        else
        {
            AiSeePlayer = false;
        }
        /*if(Ai.GetComponent<AiHealth>().aiHealth <= 99)
        {
            radius = 1000f;
        }*/
    }
}