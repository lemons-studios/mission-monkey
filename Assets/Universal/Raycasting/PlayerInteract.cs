using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float rayDistance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // Create a new ray
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.blue);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, rayDistance, mask)) {
            if(hitInfo.collider.GetComponent<Interactable>() != null) {
                // Display an interaction text if the player is looking at an interactable
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().poromptMessage);
            }
        }
    }
}
