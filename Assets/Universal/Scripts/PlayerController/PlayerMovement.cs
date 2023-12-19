using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, gravity, jumpHeight;
    public float sprintSpeedMultiplier = 2.0f;

    private PlayerInput playerInput;
    private CharacterController playerController;
    private Vector3 movementInput3d;
    private bool isPlayerGrounded;
    
    private void Start()
    {
        playerInput = new PlayerInput();
        SetDefaultMovementValues();
        playerController = GetComponent<CharacterController>();

        playerInput.OnFoot.Sprint.started += OnSprintStarted;
        playerInput.OnFoot.Sprint.canceled += OnSprintEnded;
        playerInput.Enable();
    }

    private void Update()
    {
        isPlayerGrounded = playerController.isGrounded;

        Vector2 movementInput = playerInput.OnFoot.Movement.ReadValue<Vector2>();

        // Check if PlayerInput is instantiated or has been referenced
        if (playerInput == null)
        {
            Debug.LogError("Player Input Not instantiated/referenced");
            return;
        }

        // Only run if there is actually movement
        if (movementInput.x != 0 || movementInput.y != 0)
        {
            movementInput3d = new Vector3(movementInput.x, 0, movementInput.y);
            OnMove(movementInput3d);
        }
    }

    private void OnMove(Vector3 movement)
    {
        // Something something world space movement
        Vector3 worldSpaceMovement = transform.TransformDirection(movement);

        // Move the player controller
        playerController.Move(worldSpaceMovement * moveSpeed * Time.deltaTime);
    }

    private void OnSprintStarted(InputAction.CallbackContext context)
    {
        Debug.Log("Started Sprinting");
        moveSpeed *= sprintSpeedMultiplier;
    }
    private void OnSprintEnded(InputAction.CallbackContext context)
    {
        Debug.Log("Stopped Sprinting");
        moveSpeed /= sprintSpeedMultiplier;
    }
    private void SetDefaultMovementValues()
    {
        /// Only sets anything if any of the values are less than or equal to zero
        /// Gravity does not have to be set as zero-gravity environments are a real thing
        /// Fun fact: because of me forgetting to specify a movespeed for the player, it took me 3 days to realize what I did wrong
        /// Never gonna make that mistake again

        if (moveSpeed <= 0)
        {
            moveSpeed = 5f;
        }

        if (jumpHeight <= 0)
        {
            jumpHeight = 1f;
        }
    }
}
