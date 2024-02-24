using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 100;
    private int maxHealth; 
    
    [HideInInspector]
    public bool enforceMaxHealth = true;

    private void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        if (enforceMaxHealth)
        {
            health = Mathf.Clamp(health, 0, 100);
        }

        if (health <= 0)
        {
            GetComponent<PlayerDeathController>().OnPlayerDeath();
        }
    }

    public void DamagePlayer(int DamageDealt)
    {
        health -= DamageDealt;
    }

    public void DamagePlayerRandom(int baseDamage, float minimumDamageMultiplier, float maximumDamageMultiplier)
    {
        int randomizedDamage = Mathf.RoundToInt(Random.Range(minimumDamageMultiplier, maximumDamageMultiplier));
        health -= randomizedDamage;
    }

    public void HealPlayer(int HealthHealed)
    {
        health += HealthHealed;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}
