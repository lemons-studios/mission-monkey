using UnityEngine;

// This interaction system is very similar to the old one, but I just want to have the experience of not using a tutorial to write it
public abstract class Interactable : MonoBehaviour
{
    public void TriggerInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        // Completely empty, as other scripts will be overriding this script to have their own functionality
    }
}
