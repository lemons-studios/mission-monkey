using UnityEngine;

// Anything death animation related will be added later
public class PlayerHealth : MonoBehaviour
{
    // private Animation DeathAnim;
    private HealthDisplay HealthUI;
    public int Health = 100;

    public GameObject player;
    public GameObject playerGui;
    public GameObject playerDeathScreen;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        HealthUI = Object.FindObjectOfType<HealthDisplay>();
#pragma warning restore CS0618 // Type or member is obsolete
        Mathf.Clamp(Health,0,100);
    }

    public void DamagePlayer(int DamageDealt)
    {
        Health -= DamageDealt;

        if (Health <= 0)
        {
            KillPlayer();
        }
    }
    public void HealPlayer(int HealthHealed)
    {
        Health += HealthHealed;
    }

    private void KillPlayer()
    {
        // Unlock Cursor and Load the main menu scene
        // Also set the health float value back to 100 to prevent infinite death loops upon loading into the scene
        // There is probably a better way to do this

        Cursor.lockState = CursorLockMode.Confined;
        //Time.timeScale = 0.0001f;
        Health = 100;
        playerGui.SetActive(false);
        playerDeathScreen.SetActive(true);
        playerDeathScreen.GetComponent<Animator>().SetBool("Died", true);
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Animator>().SetBool("Died", true);
        PlayerDeathController.PlayerDeath();

        // SceneManager.LoadScene("MainMenu");
    }

    private void Awake()
    {
        player.GetComponent<Animator>().enabled = false;
    }
}