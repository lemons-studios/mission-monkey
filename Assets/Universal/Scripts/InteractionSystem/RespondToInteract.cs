using UnityEngine;

public class RespondToInteract : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        Debug.Log("Successfully interacted with GameObject");
    }
}
