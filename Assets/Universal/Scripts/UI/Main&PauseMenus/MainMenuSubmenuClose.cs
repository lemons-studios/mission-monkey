using UnityEngine;
using UnityEngine.InputSystem;

// This class is ONLY to be used on the Main Menu
public class MainMenuSubmenuClose : MonoBehaviour
{
    PlayerInput playerInput;
    private GameObject currentActiveMenu;

    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += CloseMenu;
        playerInput.Enable();
    }

    private void CloseMenu(InputAction.CallbackContext context)
    {
        currentActiveMenu = GameObject.FindGameObjectWithTag("Submenu");    // Only one submenu can be open at any given time, and inactive GameObjects cannot be found
        if (currentActiveMenu != null)
        {
            currentActiveMenu.SetActive(false);
        }
        // else Debug.Log("No Submenus Active");
    }
}
