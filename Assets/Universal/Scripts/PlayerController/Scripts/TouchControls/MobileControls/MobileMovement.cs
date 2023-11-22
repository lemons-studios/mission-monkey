using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public float speed = 5f;
    public JoyStick touchJoystick;
    public bool isGrounded;
    private CharacterController characterController;
    private float gravity;
    private Vector3 playerVelocity;
    private ViewBobbing viewbobbing;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        viewbobbing = GetComponent<ViewBobbing>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        Vector2 input = touchJoystick.GetInputVector();

        Vector3 movement = Vector3.zero;
        movement.x = input.x;
        movement.z = input.y;
        if (movement.x > 0 || movement.z > 0)
        {
            viewbobbing.EnableViewBobbing();
        }
        else
        {
            viewbobbing.DisableViewBobbing();
        }
        // Make sure the movement is relative to the camera's forward direction
        movement = Camera.main.transform.TransformDirection(movement);
        // Keep the character level with the ground


        characterController.Move(transform.TransformDirection(movement) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        characterController.Move(playerVelocity * Time.deltaTime);
    }
}