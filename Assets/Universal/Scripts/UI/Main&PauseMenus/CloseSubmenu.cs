using UnityEngine;
using UnityEngine.InputSystem;

public class CloseSubmenu : MonoBehaviour
{
    // I have no idea why this script broke on the main menu but it should work again
    private PlayerInput playerInput;
    public GameObject[] mainMenuUIElements;

    private void Start() 
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += CloseActiveSubmenu;
        playerInput.Enable();
    }

    private void CloseActiveSubmenu(InputAction.CallbackContext ctx)
    {
        GameObject currentActiveMenu = GetActiveSubmenu();
        if(currentActiveMenu != null)
        {
            currentActiveMenu.SetActive(false);
        }
    }

    private GameObject GetActiveSubmenu()
    {
        foreach(GameObject currentUIElement in mainMenuUIElements)
        {
            if(currentUIElement.activeSelf)
            {
                return currentUIElement;
            }
        }
        return null;
    }

    private void OnDestroy() 
    {
        playerInput.Disable();    
    }
}
