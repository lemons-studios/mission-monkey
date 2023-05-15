using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiViolence : FieldOfView
{
    private FieldOfView fov;
    private AiGlock glock;

    private void Update()
    {
        fov = GetComponent<FieldOfView>();
        glock = GetComponent<AiGlock>();
        if (fov.canSeePlayer && !PlayerDeathController.isDead)
        {
            glock.ShootProjectile();
        }
    }
}
