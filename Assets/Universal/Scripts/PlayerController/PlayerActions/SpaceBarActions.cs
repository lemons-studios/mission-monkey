using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceBarActions : MonoBehaviour
{
    private PlayerInput playerInput;
    private CharacterController playerController;
    private Animator playerAnimator;
    private Ray vaultRay, swingRay;
    private GameObject Player;

    private string vaultTag = "Vaultable";
    private string swingableTag = "Swingable";

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();

        playerInput = new PlayerInput();
        playerInput.OnFoot.Jump.performed += JumpActionMidair;
        playerInput.Enable(); 
    }

    private void JumpActionMidair(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        bool isGrounded = playerController.isGrounded;

        vaultRay = new Ray(Player.transform.position, Vector3.forward);
        if(!isGrounded && Physics.Raycast(vaultRay, out hit))
        {
            // Finding vaultable/swingable objects in the scene is done similarly to how the weapon system determines weather the player has shot an enemy or not
            // Essentially, whatever the raycast hit detects gets checked if it has the tag we are looking for (in this case, the tag name would be "Vautable")
            // If the RaycastHit reports that the gameobject has that tag (once again, in this case it would be "Vautable"), it will then call the method to do 
            // The action assosiated with what it just it (in this case, it would call Vault())

            // One of these two actions will be prioritized over one another since they currently share the same keybind. as of writing this, vaulting will be performed if both 
            // A swingable and vaultable object are within range of the player

            Debug.DrawRay(Player.transform.position, Vector3.forward, Color.cyan);

            if(hit.collider.CompareTag(vaultTag)) // Might change this to instead look for the edge of a model insteasd of a tag, but it SHOULD work for now
            {
                Vault();
                return; // Prevents from destroying the player model in the case that both a vaultable and swingable
            }
        }
        swingRay = new Ray(Player.transform.position, Vector3.up);
        if (!isGrounded && Physics.Raycast(swingRay, out hit))
        {
            Debug.DrawRay(Player.transform.position, Vector3.forward, Color.green);
            if (hit.collider.CompareTag(swingableTag))
            {
                Swing();
                return;
            }
        }
    }

    private void Vault()
    {
        Debug.Log("Vaultable found! Performing vaulting animation right now");
    }

    private void Swing()
    {
        // Will probably get implemented a little after vauling
        Debug.Log("Swingable was found, but the code is incomplete lmao!");
    }
}
