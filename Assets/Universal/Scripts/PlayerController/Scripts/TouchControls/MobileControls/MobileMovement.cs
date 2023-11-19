using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public float speed = 5f;
    public JoyStick touchJoystick;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = touchJoystick.GetInputVector();
        Vector3 movement = new Vector3(input.x, 0, input.y);

        // Make sure the movement is relative to the camera's forward direction
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0; // Keep the character level with the ground

        characterController.Move(movement * speed * Time.deltaTime);
    }
}
