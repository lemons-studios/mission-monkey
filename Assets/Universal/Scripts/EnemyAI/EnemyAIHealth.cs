using UnityEngine;

public class EnemyAIHealth : MonoBehaviour
{
    public float health = 100;
    
    public float DamageAI(float damage)
    {
        return damage * Mathf.RoundToInt(Random.Range(0.5f, 2.0f)); // will be changed later, just needed to have this to prevent the weapon system from screaming at me
    }

    public float GetAIHealth()
    {
        return health;
    }
}
