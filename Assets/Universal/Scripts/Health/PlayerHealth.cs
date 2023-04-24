using UnityEngine;
using UnityEditor.UI;
public class PlayerHealth : DamageInfo
{
    private Canvas DeathUI;
    private Animation DeathAnim;

    public float Health = 100f;

    private PlayerMotor Motor;
    // Start is called before the first frame update
    void Start()
    {
        // (Implement later when animation exists) DeathAnim = GetComponent<>();
        DeathAnim["Die"].speed = Time.deltaTime;
        Player = GameObject.Find("Player");
        Motor = Player.GetComponent<PlayerMotor>();
    }
    
    void Update()
    {
        if (dealtDamage == false)
        {

        }
        else if (dealtDamage == true)
        {
            Health = Health - damageTaken;
        }
        if (Health == 0)
        {
            if (DeathAnim.isPlaying)
            {
                Debug.Log("Played Death Animation!");
            }

            DeathAnim.Play("Die");
        }
    }
}