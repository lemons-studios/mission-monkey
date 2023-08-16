using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealth : MonoBehaviour
{
    public static float AiMaxHealth;
    public static float AiDamageTaken;

    private void FixedUpdate()
    {
        if(AiMaxHealth <= 0 )
        {
            Destroy(gameObject);
        }
    }
    public static void DamageAI()
    {
        //AiMaxHealth = AiMaxHealth - Glock.GlockDamage;
    }
}
