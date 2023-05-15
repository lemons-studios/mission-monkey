using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathController : MonoBehaviour
{
    public static bool isDead = false;
    public static void PlayerDeath()
    {
        isDead = true;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ReloadLevel()
    {
        isDead = false;
        PlayerHealth.Health = 100f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
