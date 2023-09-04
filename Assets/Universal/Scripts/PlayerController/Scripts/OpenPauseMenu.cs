using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject[] GameUiElements;
    public GameObject[] PauseMenuElements;
    public GameObject PauseMenu, StartUI;
    private int IsOnPauseMenu = 0;
    private void Update()
    {
        if ((Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) || (Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame))
        {
            if (IsOnPauseMenu == 0)
            {
                PauseGame();
                IsOnPauseMenu++;
            }
            else if (IsOnPauseMenu == 1)
            {
                ResumeGame();
                IsOnPauseMenu--;
            }
        }
    }

    private void PauseGame()
    {
        foreach (GameObject UIElements in GameUiElements)
        {
            UIElements.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
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
        StartUI.SetActive(true);
        PauseMenu.SetActive(false);
        
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
