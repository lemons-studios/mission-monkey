using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    public float interactRayDistance = 2.5f;
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }
}
