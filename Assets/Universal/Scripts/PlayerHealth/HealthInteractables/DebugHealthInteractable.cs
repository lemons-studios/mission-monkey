using UnityEngine;

public class DebugHealthInteractable : Interactable
{
    [Tooltip("Supports Negative Values")]
    public int healthModifier;
    public PlayerHealth playerHealth;
    protected override void Interact()
    {
        base.Interact();
        playerHealth.health += healthModifier;
    }
}
