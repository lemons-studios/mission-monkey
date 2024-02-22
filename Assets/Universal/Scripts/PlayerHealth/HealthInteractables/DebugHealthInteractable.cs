using UnityEngine;

public class DebugHealthInteractable : Interactable
{
    public int healthModifier;
    private PlayerHealth playerHealth;
    public bool damagePlayer;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    protected override void Interact()
    {
        base.Interact();
        if(damagePlayer)
        {
            playerHealth.DamagePlayer(healthModifier);
        }
        else playerHealth.HealPlayer(healthModifier);
    }
}
