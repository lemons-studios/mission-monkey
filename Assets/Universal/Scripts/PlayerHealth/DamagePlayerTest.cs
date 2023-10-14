using UnityEngine;

public class DamagePlayerTest : Interactable
{
    private PlayerHealth PlayerHealth;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        PlayerHealth = Object.FindObjectOfType<PlayerHealth>();
#pragma warning restore CS0618 // Type or member is obsolete
    }

    protected override void Interact()
    {
        base.Interact();
        PlayerHealth.DamagePlayer(20);

    }
}
