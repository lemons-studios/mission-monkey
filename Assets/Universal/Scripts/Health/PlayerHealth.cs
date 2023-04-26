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

    void Start()
    {
        // DeathAnim["Die"].speed = Time.deltaTime;
        maxHealth = 100f;
    }
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
    void Update()
    {
        if (Health == 0)
        {
            // TODO
            /* DeathAnim.Play("Die");
            if (DeathAnim.isPlaying)
            {
                Debug.Log("Played Death Animation!");
            }
            */

            // For now the script will boot you back to the main menu lol
            // Unlock cursor so the player can interact with GUI elements and load the MainMenu scene
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }
}