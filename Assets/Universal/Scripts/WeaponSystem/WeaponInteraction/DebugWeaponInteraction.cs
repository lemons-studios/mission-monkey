using UnityEngine;
public class DebugWeaponInteraction : WeaponInteraction
{
    protected override void OnWeaponInteract()
    {
        Debug.Log("Hit a Weapon Interactable!");
        base.OnWeaponInteract();
    }
}
