using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public GameObject Player, PlayerDeathScreen;
    public GameObject[] PlayerUIElements;
    public void KillPlayer()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Time.timeScale = 0.0001f;
        foreach(GameObject UIElements in PlayerUIElements)
        {
            UIElements.SetActive(false);
        }
        PlayerDeathScreen.SetActive(true);
        Player.GetComponent<Animator>().enabled = true;
        Player.GetComponent<Animator>().SetBool("Died", true);
        PlayerDeathScreen.GetComponent<Animator>().SetBool("Died", true);
    }

    public void ReloadLevel()
    {
        PlayerHealth.Health = 100;
        foreach(GameObject UIElements in PlayerUIElements)
        {
            UIElements.SetActive(true);
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void LoadToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
