using UnityEngine;

public class DestroyTarget : WeaponInteract
{
    public BarrelExplosion BarrelExplosion;
    public override void TriggerInteract()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        BarrelExplosion.DestroyCounter();
    }
}