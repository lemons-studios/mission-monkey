using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactText = string.Empty; // will very likely be not used because this game might follow a differeent gameplay philosphy 
    protected virtual void TriggerInteract()
    {
        // Completely Empty, as inherited classes will determine what to do
    }
}
