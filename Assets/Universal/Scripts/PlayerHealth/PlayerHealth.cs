using UnityEngine;

// Anything death animation related will be added later
public class PlayerHealth : MonoBehaviour
{
    // private Animation DeathAnim;
    public static bool EnforceMaxHealth = true;
    public static bool dealtDamage;
    public static bool healedHealth;
    public static float damageTaken;
    public static float healthHealed;
    public static float Health = 100f;

    public GameObject player;
    public GameObject playerGui;
    public GameObject playerDeathScreen;

    public static void DamagePlayer()
    {
        if (dealtDamage == false)
        {
            // Do nothing, as the player didn't take damage
            return;
        }
        else if (dealtDamage == true)
        {
            // Debug.Log("dealt Damage!");
            Health = Health - damageTaken;
            dealtDamage = false;
            PlayerPrefs.SetFloat("CurrentHealth", Health);
        }
    }
    public static void HealPlayer()
    {
        if (healedHealth == false)
        {
            // Do nothing, as the player didn't interact with a healing item
            return;
        }
        else if (healedHealth == true)
        {
            // Debug.Log("Healed Health!");
            Health = Health + healthHealed;
            healedHealth = false;
            PlayerPrefs.SetFloat("CurrentHealth", Health);
        }
    }
    private void KillPlayer()
    {
        // Unlock Cursor and Load the main menu scene
        // Also set the health float value back to 100 to prevent infinite death loops upon loading into the scene
        // There is probably a better way to do this

        Cursor.lockState = CursorLockMode.None;
        Health = 100f;
        playerGui.SetActive(false);
        playerDeathScreen.SetActive(true);
        playerDeathScreen.GetComponent<Animator>().SetBool("Died", true);
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Animator>().SetBool("Died", true);
        PlayerDeathController.PlayerDeath();

        // SceneManager.LoadScene("MainMenu");
    }
    private void EnforceHealthCap()
    {
        Health = 100f;
    }

    void Update()
    {
        if (EnforceMaxHealth == true && Health > 101)
        {
            EnforceHealthCap();
        }
        if (Health <= 0)
        {
            // If the player health float hits zero, it kills the player
            KillPlayer();
        }
    }
    private void Awake()
    {
        Health = 100f;
        player.GetComponent<Animator>().enabled = false;
    }
    private void OnApplicationQuit()
    {

    }
}