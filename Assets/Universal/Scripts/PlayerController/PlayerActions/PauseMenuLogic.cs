using LemonStudios.CsExtensions;
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

    private void EscapeActionHandler(InputAction.CallbackContext ctx)
    {
        if(IsSubmenuActive())
        {
            // Debug.Log("Active Submenu Found");
            GameObject currentActiveSubmenu = GameObject.FindGameObjectWithTag("Submenu");
            currentActiveSubmenu.SetActive(false);
        }
        else
        {
            switch(LemonGameUtils.IsGamePaused())
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
        LemonUIUtils.SwitchMenus(gameUI, pauseUI);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; 
        LemonUIUtils.SwitchMenus(pauseUI, gameUI);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private bool IsSubmenuActive()
    {
        return GameObject.FindGameObjectWithTag("Submenu") != null;
    }
    
    private void OnDestroy() 
    {
        playerInput.Disable();
        gameUI = null;
        pauseUI = null;    
    }
}
