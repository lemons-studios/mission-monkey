using UnityEngine;
using UnityEditor.UI;
public class PlayerHealth : MonoBehaviour
{
    private Animation DeathAnim;
    // Start is called before the first frame update
    void Start()
    {
        DeathAnim["Die"].speed = Time.deltaTime;
    }

    void Update()
    {
        if (DamageInfo.dealtDamage == false)
        {

        }
        else if (DamageInfo.dealtDamage == true)
        {
            Debug.Log("dealt Damage!");
            DamageInfo.Health = DamageInfo.Health - DamageInfo.damageTaken;
            DamageInfo.dealtDamage = false;
        }
        if (DamageInfo.Health == 0)
        {
            DeathAnim.Play("Die");
            if (DeathAnim.isPlaying)
            {
                Debug.Log("Played Death Animation!");
            }

            
        }
    }
}