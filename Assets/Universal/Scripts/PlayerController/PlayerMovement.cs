using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed, jumpHeight;
    public float gravity;

    public float sprintSpeedMultiplier = 2.0f;

    private PlayerInput playerInput;
    private CharacterController playerController;
    private Vector3 playerVelocity;
    private bool isPlayerGrounded, isJumpPerformed;

    private void Start()
    {
        // Only sets anything if any of the values are less than or equal to zero
        // Fun fact: because of me forgetting to specify a movespeed for the player, it took me 3 days to realize what I did wrong
        // Never gonna make that mistake again

        if (gravity <= 0)
        {
            Debug.LogWarning("Invalid gravity value detected. Make sure that the 'gravity' variable is greater than 0. this script will use the default gravity value (9.8 m/s)");
            gravity = 9.8f;
        }

        playerInput = new PlayerInput();
        playerController = GetComponent<CharacterController>();

        var playerControllerInput = playerInput.OnFoot;
        playerControllerInput.Sprint.started += OnSprintStarted;
        playerControllerInput.Sprint.canceled += OnSprintEnded;
        playerControllerInput.Jump.performed += OnJump;
        playerInput.Enable();
    }

    private void Update()
    {

        if (playerInput != null)
        {
            isPlayerGrounded = playerController.isGrounded;
            Vector2 movementInput = playerInput.OnFoot.Movement.ReadValue<Vector2>();

            // Check if PlayerInput is instantiated or has been referenced

            Vector3 surfaceMovement = new Vector3(movementInput.x, 0, movementInput.y);
            OnMove(surfaceMovement);

            // Stol- I mean borrowed from the old player motor script
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

    private void OnMove(Vector3 movement)
    {
        // Something something world space movement
        Vector3 worldSpaceMovement = transform.TransformDirection(movement);

        // Move the player controller
        playerController.Move(worldSpaceMovement * moveSpeed * Time.deltaTime);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        // Once again stolen from playerMotor. too good to not have in this script.
        // Only reason this is being refactored in the first place is because i want to expand it more easily later down the line lol

        if (isPlayerGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * -gravity);
        }
        else return;
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
}
