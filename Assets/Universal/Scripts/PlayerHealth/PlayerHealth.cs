using UnityEngine;

// Anything death animation related will be added later
public class PlayerHealth : MonoBehaviour
{
    // private Animation DeathAnim;
    public int health = 100;

    public GameObject player, playerGui, playerDeathScreen;
    public PlayerDeathController playerDeathController;

    public void DamagePlayer(int DamageDealt)
    {
        health -= DamageDealt;

        if (health <= 0)
        {
            playerDeathController.KillPlayer();
        }
    }
    public void HealPlayer(int HealthHealed)
    {
        health += HealthHealed;
    }

    private void Update()
    {
        if (health >= 101)
        {
            health = 100;
        }
    }

    public int GetHealth()
    {
        return health;
    }

    private void Awake()
    {
        player.GetComponent<Animator>().enabled = false;
    }
}