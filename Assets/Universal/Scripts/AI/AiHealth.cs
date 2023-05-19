using UnityEngine;
public class AiHealth : MonoBehaviour
{
    public float aiDmgTaken;
    public float aiHealthHealed;
    public float aiHealth = 100f;
    public bool aiDealtDamage;
    public void DamageEnemy()
    {
        if (aiDealtDamage == false)
        {
            return;
        }
        else if (aiDealtDamage == true)
        {
            aiHealth = aiHealth - aiDmgTaken;
            aiDealtDamage = false;
        }
    }
    private void KillEnemy()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (aiHealth <= 0)
        {
            KillEnemy();
        }
    }
}
