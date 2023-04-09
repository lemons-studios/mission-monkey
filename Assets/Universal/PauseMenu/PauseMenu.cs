using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused;
    public GameObject pauseMenu;
    public void TogglePause () {
        gameIsPaused = !gameIsPaused;
        pauseMenu.SetActive(gameIsPaused);
        if (gameIsPaused) {
            PauseGame();
        } else {
            ResumeGame();
        }
    }
    void PauseGame () {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        GetComponent<InputManager>().OnDisable();
    }
    void ResumeGame () {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<InputManager>().OnEnable();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}
