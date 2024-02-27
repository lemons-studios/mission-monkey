using UnityEngine;
using UnityEngine.InputSystem;

// This script is ONLY for the pause menu
public class PauseMenuLogic : MonoBehaviour
{
    public GameObject gameUI, pauseUI;
    private PlayerInput playerInput;
    
    private void OnEnable() 
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.Pause.performed += EscapeActionHandler;  
        playerInput.Enable();

        gameUI = GameObject.FindGameObjectWithTag("GameUI");
        pauseUI = GameObject.FindGameObjectWithTag("PauseUI");
        pauseUI.SetActive(false);
    }

    public void EscapeActionHandler(InputAction.CallbackContext ctx)
    {
        if(IsSubmenuActive())
        {
            // Debug.Log("Active Submenu Found");
            GameObject currentActiveSubmenu = GameObject.FindGameObjectWithTag("Submenu");
            currentActiveSubmenu.SetActive(false);
        }
        else
        {
            switch(IsGamePaused())
            {
                case true:
                    ResumeGame();
                    break;
                case false:
                    PauseGame();
                    break;
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SwitchMenus(gameUI, pauseUI);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        SwitchMenus(pauseUI, gameUI);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private bool IsGamePaused()
    {
        // A timescale of  <= 0 indicates that the game is paused, while a higher timescale indicates that the game is not paused
        if(Time.timeScale <= 0) return true;
        else return false;
    }

    private bool IsSubmenuActive()
    {
        return GameObject.FindGameObjectWithTag("Submenu") != null;
    }

    private void SwitchMenus(GameObject menuToHide, GameObject menuToShow)
    {
        menuToHide.SetActive(false);
        menuToShow.SetActive(true);
    }

    private void OnDestroy() 
    {
        playerInput.Disable();
        gameUI = null;
        pauseUI = null;    
    }
}
