using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;    // Can be changed in the editor
    private int maxHealth;  // Max Health of the AI is needed in some methods outside this script


    private void Start()
    {
        maxHealth = health;
    }

    public void DamageAI(int damage)
    {
        health -= damage;
        if (health <= 0) GameObject.Destroy(gameObject);
    }

    public void RandomAIDamage(int damage, float maxDamageReduction, float maxDamageIncrease)
    {
        health -= Mathf.RoundToInt(damage * Random.Range(maxDamageReduction, maxDamageIncrease));
        if (health <= 0) GameObject.Destroy(gameObject);
    }

    public int GetAIHealth()
    {
        return health;
    }

    public void HealAI(int newHealth)
    {
        health += newHealth;
    }

    public int GetMaxAIHealth()
    {
        return maxHealth;
    }
}
