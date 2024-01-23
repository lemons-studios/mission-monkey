using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    public GameObject gameUI, pauseUI;
    private PlayerInput playerInput;

    private void Start() 
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += TogglePause;  
        playerInput.Enable();
    }

    private void TogglePause(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Pause toggled");
        
        if(!IsGamePaused())
        {
            Time.timeScale = 0;
            SwitchMenus(gameUI, pauseUI, false);
        }
        else
        {
            Time.timeScale = 1;
            SwitchMenus(pauseUI, gameUI, true);
        }
    }

    private bool IsGamePaused()
    {
        // A timescale of 0 indicates that the game is paused, while a higher timescale indicates that the game is not paused
        if(Time.timeScale == 0) return true;
        else return false;
    }

    private void SwitchMenus(GameObject menuToHide, GameObject menuToUnhide, bool lockCursor)
    {
        menuToHide.SetActive(false);
        menuToUnhide.SetActive(true);

        // Sets the cursor's lock state within the game depending if the player is switching to the pause menu or not
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else Cursor.lockState = CursorLockMode.None;
    }
}
