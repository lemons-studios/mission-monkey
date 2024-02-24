using System.Collections;
using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class EnemySight : MonoBehaviour
{
    // Script partially written with the help of https://www.noveltech.dev/ai-player-detection

    [Tooltip("I highly suggest having multiple detection points for you AI, or you will find deadzones for the AI where there shouldn't be")]
    public GameObject[] detectionPoints;   // Needed because some models are awful when it comes to proper detection
    private GameObject player;  // Every project requires some cursed wizzardry to work
    private LayerMask detectLayer;
    
    [Space]
    [Tooltip("X & Y axis")]
    public float detectionRadius;   // X and Y Axis
    [Tooltip("Z Axis")]
    public float detectionDepth; // Z-Axis 

    [Space]
    [Tooltip("Enable to show detection gizmo for this AI. NOTE: The gizmo is slightly innaccurate, and is only an estimate of the detection range")]
    public bool enableDetectionGizmo = false;
    public float gizmoTransperancy = 0.35f; 

    [Space]
    [Tooltip("Enable to send a message to the console whenever the player is detected (Detection check occurs every 2.5 seconds)")]
    public bool enableDebugMessages = false;

    private void Start() 
    {
        detectLayer = 1 << 3;   // Bit shift detection layer to layer 3 (Player Layer) 
        player = GameObject.FindGameObjectWithTag("Player");    // Needed for runtime in a compiled build, as OnDrawGizmos is an Editor-Only method

        if(enableDebugMessages) StartCoroutine(debugTargetDetector());
    }

    private IEnumerator debugTargetDetector()
    {
        while(true)
        {
            if(isPlayerVisible())
            {
                Debug.Log(gameObject.name + " Has detected the player");
            }
            yield return new WaitForSeconds(2.5f);  // I should probably change the debug logging interval
        }
    }
    
#if UNITY_EDITOR
    // This method is written completely with the code from the article I linked at the start of the class, it's good stuff!
    private void OnDrawGizmos()
    {
        gizmoTransperancy = Mathf.Clamp(gizmoTransperancy, 0, 1);
        player = GameObject.FindGameObjectWithTag("Player");
        if (Selection.activeGameObject == null || (Selection.activeGameObject != gameObject && !transform.IsChildOf(Selection.activeGameObject.transform)))
        {
            return;
        }
        
        if(enableDetectionGizmo)
        {
            foreach(GameObject currentDetectionPoint in detectionPoints)
            {
                if (currentDetectionPoint != null)
                {
                    // Change color to red if the player is in sight
                    if (isPlayerVisible())
                    {
                        Gizmos.color = new Color(1, 0, 0, gizmoTransperancy);
                    }
                    else Gizmos.color = new Color(0, 1, 0, gizmoTransperancy);
                    
                    Gizmos.matrix = currentDetectionPoint.transform.localToWorldMatrix;
                    Gizmos.DrawCube(new Vector3(0f, 0f, detectionDepth / 2f), new Vector3(detectionRadius, detectionRadius, detectionDepth));
                }
            }
        }
    }
#endif

    // Here is my approach to getting target detection working on my AI system: 
    // First, Fire a ShapeCast from a point (Typically that point will be the detectionPoint GameObject). 
    // Check if the player is found in the SphereCast. If the player IS in the SphereCast, fire a Raycast directly towards the player, and check
    // if it actually hits the player. This prevents situations where the player can be found if they are in range of the SphereCast
    // but are behind a GameObject where the AI should not be able to see it (For example, the player could be behind a wall that the AI may be able to see through) 
    
    // Only this bool should be public as it's the only one that needs to be called from other methods or instances of the class
    public bool isPlayerVisible()
    {
        if (isPlayerInRange())
        {
            foreach(GameObject currentDetectionPoint in detectionPoints)
            {
                Vector3 raycastOrigin = currentDetectionPoint.transform.position;
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

        }
        return false;
    }

    private bool isPlayerInRange()
    {
        foreach(GameObject currentDetectionPoint in detectionPoints)
        {
            if (detectionPoints != null)
            {
                RaycastHit hitInfo;
                if (Physics.SphereCast(currentDetectionPoint.transform.position, detectionRadius, currentDetectionPoint.transform.forward, out hitInfo, detectionDepth, detectLayer))
                {
                    return hitInfo.transform.CompareTag("Player");
                }
            }
        }
        return false;
    }
}
