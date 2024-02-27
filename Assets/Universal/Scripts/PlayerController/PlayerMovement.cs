using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    
    private PlayerInput playerInput;
    private CharacterController playerController;
    private Vector3 playerVelocity;
    public float moveSpeed, jumpHeight, gravity;
    public float sprintSpeedMultiplier = 2.0f;
    private bool isPlayerGrounded;

    private void Start()
    {
        playerController = GetComponent<CharacterController>();

        playerInput = new PlayerInput();
        var playerControllerInput = playerInput.OnFoot; // Easier to call methods when inputs are performed
        playerControllerInput.Sprint.started += OnSprintStarted;
        playerControllerInput.Sprint.canceled += OnSprintEnded;
        playerControllerInput.Jump.performed += JumpActions;
        playerInput.Enable();

        // Locks cursor in the center of the screen the moment the script starts
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update() runs once per game frame
    private void Update()
    {
        var playerControllerInput = playerInput.OnFoot; // Just makes everything slightly more simple on line 46
        isPlayerGrounded = playerController.isGrounded;

        if (playerInput != null)
        {
            OnPlayerMove(playerControllerInput.Movement.ReadValue<Vector2>());

            // Gravity for jumping
            playerVelocity.y += -gravity * Time.deltaTime;

            if (isPlayerGrounded && playerVelocity.y < 0)
            {
                playerVelocity.y = -2f;
            }
            playerController.Move(playerVelocity * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Player Input Not instantiated/referenced");
        }
    }

    private void OnPlayerMove(Vector2 movementInput)
    {
        // Creates a new Vector3 using movementInput and then converts it to world space movement
        Vector3 worldSpaceMovement = transform.TransformDirection(new Vector3(movementInput.x, 0, movementInput.y));

        // Move the player controller based on the world space movement
        playerController.Move(worldSpaceMovement * (moveSpeed * Time.deltaTime));
    }

    private void JumpActions(InputAction.CallbackContext context)
    {
        if (isPlayerGrounded)
        {
            // Once again stolen from playerMotor. too good to not have in this script.
            // Only reason this is being refactored in the first place is because i want to expand it more easily later down the line lol
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * -gravity);
        }
    }

    private void OnSprintStarted(InputAction.CallbackContext context)
    {
        // Might make the sprinting math different later but this works for now
        moveSpeed *= sprintSpeedMultiplier;
    }
    private void OnSprintEnded(InputAction.CallbackContext context)
    {
        moveSpeed /= sprintSpeedMultiplier;
    }

    private void OnDestroy()
    {
        playerInput.Disable();
    }
}
