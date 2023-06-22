using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float JumpCapCheck = 0f;
    public PlayerInput.OnFootActions onFoot;
    private PlayerLook look;

    private PlayerMotor motor;
    private PlayerInput playerInput;

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
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        Cursor.lockState = CursorLockMode.Locked;
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        // Tell the player motor to move from the movement ingame
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>(), onFoot.Sprint.ReadValue<float>() > 0);
    }
    private void Update()
    {
        if (PlayerDeathController.isDead)
        {
            OnDisable();
        }
        else
        {
            OnEnable();
        }
    }
}