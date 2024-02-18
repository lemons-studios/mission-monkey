using UnityEngine;

public class DebugHealthInteractable : Interactable
{
    [Tooltip("Supports Negative Values")]
    public int healthModifier;
    public PlayerHealth playerHealth;
    public bool damagePlayer;
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
