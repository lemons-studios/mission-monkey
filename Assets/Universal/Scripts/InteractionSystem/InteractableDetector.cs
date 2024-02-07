using UnityEngine;

public class InteractableDetector : MonoBehaviour
{
    private Camera mainCamera;
    private PlayerInput playerInput;
    public LayerMask interactableMask;
    public float interactRayDistance = 2.5f;

    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Interact.performed += ctx => FindInteractables();
        playerInput.Enable();
        mainCamera = GetComponentInChildren<Camera>();
    }
    private void FindInteractables()
    {
        Ray interactionRaycast = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(interactionRaycast, out hit, interactRayDistance, interactableMask))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Debug.Log("Performing interact with interactable GameObject");
                hit.collider.GetComponent<Interactable>().TriggerInteract();
            }
        }
    }

    private void OnDestroy() 
    {
        playerInput.Disable();    
    }
}
