using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class InputManager : MonoBehaviour
{
    public float JumpCapCheck = 0f;
    public PlayerInput.OnFootActions onFoot;
    
    private PlayerLook look;
    public CameraMove cameraMove;
    private PlayerMotor motor;
    private PlayerInput playerInput;

    public JoyStick touchJoystick;
    public bool mobileControl;
    public void OnDisable()
    {
        onFoot.Disable();
    }

    public void OnEnable()
    {
        onFoot.Enable();
    }
    private void LateUpdate()
    {
        if (mobileControl)
        {
            look.ProcessLook(cameraMove.touchDelta);
        }
        else
        {
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
    }
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        Cursor.lockState = CursorLockMode.Locked;
        onFoot.Jump.performed += ctx => motor.Jump();
        cameraMove = GetComponentInChildren<CameraMove>();
    }

    void FixedUpdate()
    {
        // Tell the player motor to move from the movement ingame
        if(mobileControl)
        {
            motor.ProcessMove(touchJoystick.GetInputVector(), onFoot.Sprint.ReadValue<float>() > 0);
        }
        else
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>(), onFoot.Sprint.ReadValue<float>() > 0);
        }

        
        
      

    }
    private void Update()
    {
        if (gameObject.GetComponent<PlayerHealth>().Health <= 0)
        {
            OnDisable();
        }
        else
        {
            OnEnable();
        }
    }
}