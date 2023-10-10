public class DebugWeaponInteraction : WeaponInteract
{

    public override void TriggerInteract()
    {
        Debug.Log("Hit a Weapon Interactable!");
        base.TriggerInteract();
    }
}
