using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceBarActions : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = new PlayerInput();

        playerInput.OnFoot.Jump.performed += SpacebarHandler;

        playerInput.Enable();
    }

    private void SpacebarHandler(InputAction.CallbackContext context)
    {
        Debug.Log("Performed");
    }
}
