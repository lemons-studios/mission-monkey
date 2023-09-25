using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeSight : MonoBehaviour
{
    public GameObject player;
    public LayerMask obstructionMask;
    public float detectionRange = 10f;
    public float fieldOfViewAngle = 60f;
    private Transform enemyTransform;
    public bool seePlayer = false;

    void Start()
    {
        enemyTransform = transform;
        player = GameObject.FindGameObjectWithTag("Player");
          seePlayer = false;
}

    void Update()
    {
        Vector3 directionToPlayer = player.transform.position - enemyTransform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

       
        // Limit the detection range based on the distance to the player
        float effectiveDetectionRange = Mathf.Min(detectionRange, distanceToPlayer);

        // Check if the player is within the effective detection range
        if (distanceToPlayer <= effectiveDetectionRange)
        {
            // Check if the player is within the field of view angle
            float angleToPlayer = Vector3.Angle(enemyTransform.forward, directionToPlayer);

            if (angleToPlayer <= fieldOfViewAngle * 0.5f)
            {
                // Cast a ray from the enemy to the player to check for obstructions
                Ray ray = new Ray(enemyTransform.position, directionToPlayer.normalized);
                RaycastHit hit;

                // Check for obstructions between the enemy and player
                if (Physics.Raycast(ray, out hit, effectiveDetectionRange, obstructionMask))
                {
                    // There is an obstruction between the enemy and player
                    if (hit.transform != player.transform)
                    {
                        Debug.DrawLine(ray.origin, hit.point, Color.red);
                        // Enemy can't see the player due to an obstruction
                        seePlayer = false;
                    }
                }
                else
                {
                    // No obstructions between the enemy and player
                    Debug.DrawLine(ray.origin, player.transform.position, Color.green);
                   
                    seePlayer = true;
                    // Handle what the enemy does when it sees the player
                }
            }
        }
    }
}


