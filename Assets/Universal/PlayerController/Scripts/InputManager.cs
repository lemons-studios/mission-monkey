using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    public float JumpCapCheck = 0f;
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
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate() {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() {
        onFoot.Enable();    
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}