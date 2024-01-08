using UnityEngine;

public class DebugHealthInteractable : Interactable
{
    [Tooltip("Supports Negative Values")]
    public int healthModifier;
    public PlayerHealth playerHealth;
    protected override void Interact()
    {
        base.Interact();
        playerHealth.DamagePlayer(healthModifier);
        Debug.Log("Health remaining: " + playerHealth.GetHealth());
    }
}
