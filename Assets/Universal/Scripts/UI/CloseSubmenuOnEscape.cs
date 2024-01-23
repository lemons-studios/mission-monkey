using UnityEngine;
using UnityEngine.InputSystem;

public class CloseSubmenuOnEscape : MonoBehaviour
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
