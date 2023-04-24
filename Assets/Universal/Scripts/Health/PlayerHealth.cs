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
        DeathAnim["Die"].speed = 1/Time.deltaTime;
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
            DeathAnim.Play("Die");
            if (DeathAnim.isPlaying)
            {
                Debug.Log("Played Death Animation!");
            }
        }
    }
}