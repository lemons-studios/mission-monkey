using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFOV : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject ai;

    [SerializeField]
    private float turretRange;

    public LayerMask obstructionMask;

    private AiGlock glock;

    private void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        bool canSeePlayer = !Physics.Raycast(transform.position, directionToPlayer, distToPlayer, obstructionMask);

        glock = GetComponent<AiGlock>();

        if (canSeePlayer && !PlayerDeathController.isDead)
        {
            Vector3 targetDirection = player.transform.position - ai.transform.position;
            //gameObject.transform.rotation.Set(0, targetDirection.normalized.z * 180, 0, 0);
            gameObject.transform.rotation.SetFromToRotation(transform.position, player.transform.position);
            Debug.Log(targetDirection.normalized.z * 180);
            glock.ShootProjectile();
        }
    }
}
