using UnityEngine;

// Anything death animation related will be added later
public class PlayerHealth : MonoBehaviour
{
    // private Animation DeathAnim;
    private HealthDisplay HealthUI;
    public int Health = 100;

    public GameObject player, playerGui, playerDeathScreen;
    public PlayerDeathController playerDeathController;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        HealthUI = Object.FindObjectOfType<HealthDisplay>();
#pragma warning restore CS0618 // Type or member is obsolete
        Mathf.Clamp(Health,0,100);
    }

    public void DamagePlayer(int DamageDealt)
    {
        Health -= DamageDealt;

        if (Health <= 0)
        {
            playerDeathController.KillPlayer();
        }
    }
    public void HealPlayer(int HealthHealed)
    {
        Health += HealthHealed;
    }

    private void Update()
    {
        if(Health >= 101)
        {
            Health = 100;
        }
    }



    private void Awake()
    {
        player.GetComponent<Animator>().enabled = false;
    }
}