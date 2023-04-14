using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineOfSight : MonoBehaviour
{
    public float rayLength = 10f;
    private RaycastHit vision;
    private InputAction interactAction;

    void OnEnable()
    {
        interactAction = new InputAction(binding: "<Keyboard>/e;<Gamepad>/buttonSouth");
        interactAction.Enable();
    }

    void OnDisable()
    {
        interactAction.Disable();
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * rayLength, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out vision, rayLength))
        {
            if (vision.collider.CompareTag("Interactive"))
            {
                Debug.Log("Looking at: " + vision.collider.name);

                if (interactAction.triggered)
                {
                    IInteractable interactable = vision.collider.GetComponent<IInteractable>();
                    if (interactable != null)
                    {
                        interactable.Interact();
                    }
                }
            }
        }
    }
}
