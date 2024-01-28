using UnityEngine;
using UnityEngine.InputSystem;

// This class is ONLY to be used on the Main Menu
public class MainMenuSubmenuClose : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject uiToHide;
    
    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += CloseMenu;
        playerInput.Enable();
    }

    private void CloseMenu(InputAction.CallbackContext context)
    {
        uiToHide.SetActive(false);   
    }
}
