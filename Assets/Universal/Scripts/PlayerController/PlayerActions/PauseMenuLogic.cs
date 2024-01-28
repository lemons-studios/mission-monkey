using UnityEngine;
using UnityEngine.InputSystem;


public class PauseMenuLogic : MonoBehaviour
{
    public GameObject gameUI, pauseUI;
    public GameObject[] pauseUISubmenus;
    private PlayerInput playerInput;
    private void Start() 
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += EscapeActionHandler;  
        playerInput.Enable();
    }

    // The DisableInputAction() and EnableInputAction() methods are specifically for the game to not unpause when the player 
    // performs the "pause" action in a submenu of the pause menu (where the same action can close the submenu).
    // A similar process happens there to prevent it from conflicting with the pause action in this script
    public void DisableInputAction()
    {
        playerInput.Disable();
    }
    public void EnableInputAction()
    {
        playerInput.Enable();
    }

    private void EscapeActionHandler(InputAction.CallbackContext callbackContext)
    {
        if(IsSubmenuActive())
        {
            for(int i = 0; i < pauseUISubmenus.Length; i++)
            {
                if(pauseUISubmenus[i].activeInHierarchy)
                {
                    // I designed the pause menu
                    pauseUISubmenus[i].SetActive(false);
                    break;
                }
            }
        }
        else 
        {
            switch(IsGamePaused())
            {
                case true:
                    Time.timeScale = 1;

                    SwitchMenus(pauseUI, gameUI, true);
                    break;
                case false:
                    Time.timeScale = 0;
                    SwitchMenus(gameUI, pauseUI, false);
                    break;
            }
        }
        // Debug.Log("Pause toggled");
    }

    private bool IsGamePaused()
    {
        // A timescale of  <= 0 indicates that the game is paused, while a higher timescale indicates that the game is not paused
        if(Time.timeScale <= 0) return true;
        else return false;
    }

    private bool IsSubmenuActive()
    {
        if(IsGamePaused())
        {
            for(int i = 0; i < pauseUISubmenus.Length; i++)
            {
                if(pauseUISubmenus[i].activeSelf == true)
                {
                    if(pauseUISubmenus[i].activeInHierarchy)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
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
