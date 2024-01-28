using UnityEngine;
using UnityEngine.InputSystem;

public class CloseSubmenuOnEscape : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject uiToHide;
    private PauseGame pauseGame;
    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += CloseMenu;
        playerInput.Enable();

        // PauseGame will only ever be on the player
        // pauseGame = GameObject.FindGameObjectWithTag("Player").GetComponent<PauseGame>();
    }

    private void CloseMenu(InputAction.CallbackContext context)
    {
        uiToHide.SetActive(false);   
    }
}
