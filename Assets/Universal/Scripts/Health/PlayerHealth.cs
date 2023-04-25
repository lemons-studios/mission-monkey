using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    private Animation DeathAnim;
    public static bool dealtDamage;
    public GameObject Player;
    public static float damageTaken;
    public static float Health = 100f;
    
    void Start()
    {
        DeathAnim["Die"].speed = Time.deltaTime;
    }

    void Update()
    {
        if (dealtDamage == false)
        {

        }
        else if (dealtDamage == true)
        {
            Debug.Log("dealt Damage!");
            Health = Health - damageTaken;
            dealtDamage = false;
        }
        if (Health == 0)
        {
            DeathAnim.Play("Die");
            if (DeathAnim.isPlaying)
            {
                Debug.Log("Played Death Animation!");
            }

            
        }
    }
}