using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    private PlayerInput playerInput = new PlayerInput();
    private CharacterController playerController;
    private bool isPlayerGrounded;
    private float moveSpeed;
    public float sprintSpeedMultiplier = 2.0f;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
        isPlayerGrounded = playerController.isGrounded;

        playerInput.OnFoot.Sprint.started += OnSprintStarted;
        playerInput.OnFoot.Sprint.canceled += OnSprintEnded;
        playerInput.Enable();
    }

    private void OnSprintStarted(InputAction.CallbackContext ctx)
    {
        moveSpeed *= sprintSpeedMultiplier;
    }
    private void OnSprintEnded(InputAction.CallbackContext ctx)
    {
        moveSpeed /= sprintSpeedMultiplier;
    }
}
