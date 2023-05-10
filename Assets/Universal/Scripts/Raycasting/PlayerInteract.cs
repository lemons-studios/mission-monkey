using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float rayDistance = 3.5f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // Create a new ray
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.blue);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, rayDistance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                // Display an interaction text if the player is looking at an interactable
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
