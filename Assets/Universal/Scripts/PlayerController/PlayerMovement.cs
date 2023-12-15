using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    private PlayerInput playerInput;
    private CharacterController playerController;
    private bool isPlayerGrounded;
    private Vector2 movementInput;

    private float moveSpeed;
    public float sprintSpeedMultiplier = 2.0f;
    public float gravity;

    private void Start()
    {
        playerInput = new PlayerInput();
        playerController = GetComponent<CharacterController>();
        
        isPlayerGrounded = playerController.isGrounded;

        playerInput.OnFoot.Sprint.started += OnSprintStarted;
        playerInput.OnFoot.Sprint.canceled += OnSprintEnded;

        playerInput.Enable();
    }

    private void MovePlayer()
    {

    }

    private void SpaceActionHander(InputAction.CallbackContext ctx)
    {
        if(isPlayerGrounded)
        {
            Jump();
        }
        else
        {
            // TODO: Write handling to check if the player can vault onto an object of attach to bars if they are looking at them and are near one
        }
    }

    private void Jump()
    {

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
