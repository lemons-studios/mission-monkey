using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController playerController;
    private Vector2 movementInput;
    public Transform Player;

    public float moveSpeed;
    public float sprintSpeedMultiplier = 2.0f;

    private void Start()
    {
        // If the movement speed is never set, set it to the default move speed
        if (moveSpeed <= 0)
        {
            moveSpeed = 5f;
        }

        playerInput = new PlayerInput();
        playerController = GetComponent<CharacterController>();

        playerInput.OnFoot.Sprint.started += OnSprintStarted;
        playerInput.OnFoot.Sprint.canceled += OnSprintEnded;

        playerInput.Enable();
    }

    // A LOT of this code was stolen from the old input system, but is now just better because it's slightly more cleaned up

    private void Update()
    {
        Vector2 movementThisFrame = playerInput.OnFoot.Movement.ReadValue<Vector2>();
        if (playerInput == null)
        {
            Debug.LogError("Player Input Not Instantiated or referenced!");
            return;
        }

        // Only run if there is actually movement
        if (movementThisFrame.x != 0 || movementThisFrame.y != 0)
        {
            Debug.Log("Movement Found! " + movementThisFrame.ToString());

            // Convert the movement value (Vector2) to a Vector3
            Vector3 threeDimensionalMovementThisFrame = new Vector3(movementThisFrame.x, 0f, movementThisFrame.y);

            // Something something world space movement
            Vector3 worldSpaceMovement = transform.TransformDirection(threeDimensionalMovementThisFrame);

            // Move the player controller
            playerController.Move(worldSpaceMovement * moveSpeed * Time.deltaTime);
            return;
        }

        return;
    }

    private void OnSprintStarted(InputAction.CallbackContext ctx)
    {
        Debug.Log("Started Sprinting");
        moveSpeed *= sprintSpeedMultiplier;
    }
    private void OnSprintEnded(InputAction.CallbackContext ctx)
    {
        Debug.Log("Stopped Sprinting");
        moveSpeed /= sprintSpeedMultiplier;
    }
}
