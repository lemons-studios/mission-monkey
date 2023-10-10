using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject[] GameUiElements;
    public GameObject[] PauseMenuElements;
    public GameObject PauseMenu, StartUI; // StartUI is the main pause menu stuff
    public PlayerInput Input;
    private int IsOnPauseMenu = 0;
    private AudioSource[] AudioInScene;


    private void Start()
    {
        Input = new PlayerInput();
        Input.OnFoot.PauseGame.performed += PauseHandler;
        Input.Enable();
#pragma warning disable CS0618 // Type or member is obsolete
        AudioInScene = Object.FindObjectsOfType<AudioSource>();
#pragma warning restore CS0618 // Type or member is obsolete

    }

    private void PauseHandler(InputAction.CallbackContext context)
    {
        switch (IsOnPauseMenu)
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

        foreach (AudioSource GameAudio in AudioInScene)
        {
            GameAudio.Pause();
        }

        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    private void ResumeGame()
    {
        foreach (GameObject UIElements in GameUiElements)
        {
            UIElements.SetActive(true);
        }


        foreach (AudioSource GameAudio in AudioInScene)
        {
            GameAudio.Play();
        }

        foreach (GameObject PauseUIElements in PauseMenuElements)
        {
            PauseUIElements.SetActive(false);
        }
        StartUI.SetActive(true); // The previous foreach statement disabled all of the Pause menu UI elements, and pausing again would result in not seeing anything. Re-Enable the Main Pause Menu GUI (Should have named it better but whatever)
        PauseMenu.SetActive(false);

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
