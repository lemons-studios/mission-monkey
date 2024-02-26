using UnityEngine;

public abstract class WeaponInteraction : MonoBehaviour
{
    public bool enableDebugMessages = false;
    protected virtual void OnWeaponInteract()
    {
        // NOTHING
    }

    public void PerformWeaponInteraction()
    {
        // Needed for the weapon system to interact with the weapon interact system (It works so i don't care)
        OnWeaponInteract();
    }
}
