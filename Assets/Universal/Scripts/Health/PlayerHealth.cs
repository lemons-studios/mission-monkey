using UnityEngine;

public class PlayerHealth : DamageInfo
{
    private PlayerUI deathUI;
    public float Health = 100f;

    private PlayerMotor Motor;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Motor = Player.GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
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

        }
    }
}