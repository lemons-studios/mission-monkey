using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject gameUI, pauseUI;
    private PlayerInput playerInput;

    private void Start() 
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.PauseGame.performed += ctx => TogglePause();  
    }

    private void TogglePause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
            gameUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            gameUI.SetActive(false);
            pauseUI.SetActive(true);
        }
    }
}
