using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    public bool enforceMaxHealth = true;

    private void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void Update()
    {
        if (enforceMaxHealth)
        {
            health = Mathf.Clamp(health, 0, 100);
        }
    }

    public void DamagePlayer(int DamageDealt)
    {
        health -= DamageDealt;
        Debug.Log(GetHealth());

        if (health <= 0)
        {
            GetComponent<PlayerDeathController>().OnPlayerDeath();
        }
    }

    public void HealPlayer(int HealthHealed)
    {
        health += HealthHealed;
    }

    public int GetHealth()
    {
        return health;
    }
    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}
