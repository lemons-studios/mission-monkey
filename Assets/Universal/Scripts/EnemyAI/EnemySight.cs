using UnityEngine;

public class EnemySight : MonoBehaviour
{
    // Script partially written with the help of https://www.noveltech.dev/ai-player-detection
    public GameObject detectionPoint;   // Needed because some models are awful when it comes to proper detection
    private GameObject player;  // Every project requires some cursed wizzardry to work
    public float detectionRadius;   // X and Y Axis
    public float detectionDepth; // Z-Axis 

    public LayerMask detectLayer;

    [Tooltip("Enable to show detection gizmo for this AI. NOTE: the actual detection range is slightly longer than what the gizmo shows")]
    public bool enableDetectionGizmo = false; 

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    private void Update() 
    {
        if(isPlayerVisible()) {Debug.Log("Detected");}
    }

    
    private void OnDrawGizmos()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (enableDetectionGizmo && detectionPoint != null)
        {
            // Change color to red if the player is in sight
            if (isPlayerVisible())
            {
                Gizmos.color = Color.red;
            }
            else Gizmos.color = Color.green;

            Gizmos.matrix = detectionPoint.transform.localToWorldMatrix;
            Gizmos.DrawCube(new Vector3(0f, 0f, detectionDepth / 2f), new Vector3(detectionRadius, detectionRadius, detectionDepth));
        }
    }


    private bool isPlayerInRange()
    {
        if (detectionPoint != null)
        {
            RaycastHit hitInfo;
            if (Physics.SphereCast(detectionPoint.transform.position, detectionRadius, detectionPoint.transform.forward, out hitInfo, detectionDepth, detectLayer))
            {
                return hitInfo.transform.CompareTag("Player");
            }
        }
        return false;
    }

    private bool isPlayerVisible()
    {
        if (isPlayerInRange())
        {
            Vector3 raycastOrigin = detectionPoint.transform.position;
            Vector3 directionToTarget = (player.transform.position - raycastOrigin).normalized;

            RaycastHit hit;

            // Prevents ray from showing up in editor
            if(Application.isPlaying)
            {
                Debug.DrawRay(raycastOrigin, directionToTarget * detectionDepth, Color.cyan);
            }
            if (Physics.Raycast(raycastOrigin, directionToTarget, out hit, detectionDepth))
            {
                return hit.transform.CompareTag("Player");
            }
        }
        return false;
    }
}
