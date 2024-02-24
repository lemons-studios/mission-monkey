using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    public LoadSave loadSave;
    public PauseMenuLogic pauseGame;
    public GameObject mainUI, deathUI;

    private void Start()
    {
        mainUI = GameObject.FindGameObjectWithTag("GameUI");
        deathUI = GameObject.FindGameObjectWithTag("DeathUI");
        deathUI.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        mainUI.SetActive(false);
        pauseGame.enabled = false;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        deathUI.SetActive(true);
    }

    public void ReloadFromLastSave()
    {
        loadSave.LoadSaveData();
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDestroy() 
    {
        mainUI = null;
        deathUI = null;    
    }
}
