using UnityEngine;
using UnityEngine.SceneManagement;

// Anything death animation related will be added later
public class PlayerHealth : MonoBehaviour
{
    // private Animation DeathAnim;
    private float maxHealth;
    public static bool dealtDamage;
    public static bool healedHealth;
    public GameObject Player;
    public static float damageTaken;
    public static float healthHealed;
    public static float Health = 100f;

    public static void DamagePlayer()
    {
        if (dealtDamage == false)
        {
            // Do nothing, as the player didn't take damage
            return;
        }
        else if (dealtDamage == true)
        {
            Debug.Log("dealt Damage!");
            Health = Health - damageTaken;
            dealtDamage = false;
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
            Debug.Log("Healed Health!");
            Health = Health + healthHealed;
            healedHealth = false;
        }
    }
    private void KillPlayer()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
        Health = 100f;
    }
    void Update()
    {
        if (Health == 0)
        {
            KillPlayer();
        }
    }
}