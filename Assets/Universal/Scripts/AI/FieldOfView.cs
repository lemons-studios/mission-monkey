using System;
using System.Collections;
using UnityEngine;
public class FieldOfView : MonoBehaviour
{
    //public GameObject Ai;
    [Range(0, 130)]
    public float angle;
    public bool canSeePlayer;
    public static bool AiSeePlayer;
    public LayerMask obstructionMask;

    public GameObject playerRef;
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
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    targetPos = GetComponent<AIPathfinding>().target;
                    if (Vector3.Distance(transform.position, targetPos) < 10)
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
        playerRef = GameObject.FindGameObjectWithTag("Player");
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
