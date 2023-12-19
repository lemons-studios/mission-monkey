using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceBarActions : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController playerController;
    private Animator playerAnimator;


    private bool isGrounded;
    public string vaultTag = "Vaultable";
    public float gravity, maximumVaultRange, maximumJumpHeight;

    private void Start()
    {
        if(maximumVaultRange <= 0)
        {
            maximumVaultRange = 0.5f; // 0.5 Meters (50cm)
        }

        if(maximumJumpHeight <= 0)
        {
            maximumJumpHeight = 1; // 1 Meter
        }

        playerAnimator = GetComponent<Animator>();

        playerController = GetComponent<CharacterController>();

        playerInput = new PlayerInput();
        playerInput.OnFoot.Jump.performed += SpacebarHandler;
        playerInput.Enable();
    }
    private void Update()
    {
        isGrounded = playerController.isGrounded;
    }

    private void SpacebarHandler(InputAction.CallbackContext context)
    {
        // Debug.Log("Performed");
        if (isGrounded)
        {
            Jump();
        }
        else
        {
            Vault();
        }
    }

    private void Jump()
    {
        Debug.Log("Jump Method Triggered");

        Vector3 jumpMovement = Vector3.zero;
        jumpMovement.y += gravity * Time.deltaTime;

        playerController.Move(jumpMovement * Time.deltaTime);
    }

    private void Vault()
    {

    }
}
