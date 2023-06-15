using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TurretFOV : MonoBehaviour
{
    public LayerMask obstructionMask;

    [SerializeField]
    private GameObject ai;

    private AiGlock glock;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float turretRange;

    private void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        bool canSeePlayer = !Physics.Raycast(
            transform.position,
            directionToPlayer,
            distToPlayer,
            obstructionMask
        );

        Ray ray = new Ray(
            transform.position,
            (player.transform.position - transform.position).normalized
        );
        RaycastHit hit;

        glock = GetComponent<AiGlock>();

        if (canSeePlayer && !PlayerDeathController.isDead)
        {
            Vector3 targetDirection = (
                ai.transform.position - player.transform.position
            ).normalized;

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(targetDirection, Vector3.forward),
                1f
            );

            if (Application.isPlaying)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        glock.ShootProjectile();
                    }
                }
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.Euler(0, 0, 0),
                1f
            );
        }
    }
}
