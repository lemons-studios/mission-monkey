using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject[] GameUiElements;
    public GameObject[] PauseMenuElements;
    public GameObject PauseMenu, StartUI; // StartUI is the main pause menu stuff
    public PlayerInput Input;
    private int IsOnPauseMenu = 0;

    private void Start()
    {
        Input = new PlayerInput();
        Input.OnFoot.PauseGame.performed += PauseHandler;
        Input.Enable();
    }

    private void PauseHandler(InputAction.CallbackContext context)
    {
        switch(IsOnPauseMenu)
        {
            case 0:
                PauseGame();
                IsOnPauseMenu++;
                break;
            case 1:
                ResumeGame();
                IsOnPauseMenu--;
                break;
        }
    }

    private void PauseGame()
    {
        foreach (GameObject UIElements in GameUiElements)
        {
            UIElements.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0.001f;
        PauseMenu.SetActive(true);
    }
    private void ResumeGame()
    {
        foreach (GameObject UIElements in GameUiElements)
        {
            UIElements.SetActive(true);
        }
        
        foreach(GameObject PauseUIElements in PauseMenuElements)
        {
            PauseUIElements.SetActive(false);
        }
        StartUI.SetActive(true); // The previous foreach statement disabled all of the Pause menu UI elements, and pausing again would result in not seeing anything. Re-Enable the Main Pause Menu GUI (Should have named it better but whatever)
        PauseMenu.SetActive(false);
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
