using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
    public static bool isDead = false;
    private PlayerHealth PlayerHealth;

    private void Start()
    {
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    public static void PlayerDeath()
    {
        isDead = true;
    }
    public void ReloadLevel()
    {
        isDead = false;
        PlayerHealth.Health = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PlayerRevive()
    {
        isDead = false;
    }
    public void LoadToMainMenu()
    {
        isDead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
