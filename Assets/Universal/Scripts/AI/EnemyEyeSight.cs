using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyeSight : MonoBehaviour
{
    public float coneAngle = 45f;
    public float coneDistance = 5f;
    public float verticalOffset = 1f; // Vertical offset for the cone
    public int rayCount = 30;
    public LayerMask obstacleLayer;
    public string playerTag = "Player"; // Set this to the tag of your player object.

    private void OnDrawGizmos()
    {
        DrawConeOutline();
    }

    private void DrawConeOutline()
    {
        // ... (Same code for drawing the cone outline)
    }

    private void Update()
    {
        // Check for hits with the specified tag during gameplay
        Vector3 origin = transform.position;
        Quaternion rotation = transform.rotation;

        // Apply the vertical offset to the origin
        origin += Vector3.up * verticalOffset;

        float halfAngle = coneAngle * 0.5f;
        float angleIncrement = coneAngle / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float currentAngle = -halfAngle + (i * angleIncrement);
            Vector3 direction = rotation * Quaternion.Euler(0, currentAngle, 0) * Vector3.forward;

            RaycastHit hit;

            // Raycast
            if (Physics.Raycast(origin, direction, out hit, coneDistance, obstacleLayer))
            {
                // Check if the hit object has the specified tag
                if (hit.collider.CompareTag(playerTag))
                {
                    Debug.Log("Hit Player in Update");
                }
            }
        }

        // Check for hits with the specified tag above the cone
        Vector3 aboveOrigin = origin + Vector3.up * verticalOffset;
        RaycastHit aboveHit;

        if (Physics.Raycast(aboveOrigin, Vector3.down, out aboveHit, verticalOffset, obstacleLayer))
        {
            if (aboveHit.collider.CompareTag(playerTag))
            {
                Debug.Log("Player Above Cone");
            }
        }

        // Add your other runtime logic here
    }
}


