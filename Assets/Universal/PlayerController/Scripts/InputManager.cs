using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float JumpCapCheck = 0f;
    private PlayerLook look;

    private PlayerMotor motor;
    public PlayerInput.OnFootActions onFoot;
    private PlayerInput playerInput;

    public void OnDisable() {
        onFoot.Disable();
    }

    public void OnEnable() {
        onFoot.Enable();
    }
    private void LateUpdate() {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    void Awake() {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        Cursor.lockState = CursorLockMode.Locked;
        onFoot.Jump.performed  += ctx => motor.Jump();
    }

    void FixedUpdate() {
        // Tell the player motor to move from the movement ingame
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>(), onFoot.Sprint.ReadValue<float>() > 0);
    }
}