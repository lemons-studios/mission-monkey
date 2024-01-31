using UnityEngine;

public class EnemyAIHealth : MonoBehaviour
{
    public string enemyName;
    public int health = 100;
    private int maxHealth;
    

    private void Start() 
    {
        maxHealth = health;    
    }

    public void DamageAI(int damage)
    {
        health -= damage; 
        if(health <= 0) GameObject.Destroy(gameObject);
    }

    public void RandomAIDamage(int damage, float maxDamageReduction, float maxDamageIncrease)
    {
        health -= Mathf.RoundToInt(damage * Random.Range(maxDamageReduction, maxDamageIncrease));
        if(health <= 0) GameObject.Destroy(gameObject);
    }

    public int GetAIHealth()
    {
        return health;
    }

    public int GetMaxAIHealth()
    {
        return maxHealth;
    }

    public string GetAIName()
    {
        return enemyName;
    }
}
