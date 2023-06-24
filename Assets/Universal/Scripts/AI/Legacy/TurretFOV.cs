using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TurretFOV : MonoBehaviour
{
    public LayerMask obstructionMask;

    [SerializeField]
    private GameObject ai;

    [SerializeField]
    private bool isSubturret;

    [SerializeField]
    private GameObject player;

    private AiTurret turret;

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

        turret = GetComponent<AiTurret>();

        if (canSeePlayer && !PlayerDeathController.isDead)
        {
            Vector3 targetDirection = (
                ai.transform.position - player.transform.position
            ).normalized;

            if (!isSubturret)
            {
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(targetDirection, Vector3.forward),
                    5f
                );
            }

            if (Application.isPlaying)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("Player") && isSubturret)
                    {
                        turret.ShootProjectile();
                    }
                }
            }
        }
        else
        {
            if (!isSubturret)
            {
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.Euler(0, 0, 0),
                    5f
                );
            }
        }
    }
}
