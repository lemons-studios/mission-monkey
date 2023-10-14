using UnityEngine;

public class DisableTurrets : Interactable
{
    public TurretAI[] Turrets;

    protected override void Interact()
    {
        base.Interact();
        foreach (TurretAI Turrets in Turrets)
        {
            Turrets.enabled = false;
        }
        promptMessage = string.Empty;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}