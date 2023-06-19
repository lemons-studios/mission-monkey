using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private InputAction spaceAction;
    private CharacterController controller;
    private ViewBobbing viewbobbing;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float gravity = -20f;
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float jumpHeight = 1f;
    public float jumpCap = 1f;

    // Start is called before the first frame update
    void Start()
    {
        viewbobbing = GetComponent<ViewBobbing>();
        controller = GetComponent<CharacterController>();
        spaceAction = new InputAction("disableSpacebar", InputActionType.Button, "<Keyboard>/space");
        // spaceAction.performed += ctx => Debug.Log("Spacebar Disabled");
        // spaceAction.canceled += ctx => Debug.Log("Spacebar enabled");

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // Receive the inputs from the inputmanager.cs file 

    public void ProcessMove(Vector2 input, bool isSprinting)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        if (moveDirection.x > 0 || moveDirection.z > 0)
        {
            viewbobbing.EnableViewBobbing();
        }
        else
        {
            viewbobbing.DisableViewBobbing();
        }

        float currentSpeed = isSprinting ? sprintSpeed : speed;
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            spaceAction.Enable();
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        else if (!isGrounded)
        {
            spaceAction.Disable();
        }
    }
}