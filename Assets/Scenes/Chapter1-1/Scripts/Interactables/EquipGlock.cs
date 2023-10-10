using UnityEngine;

public class EquipGlock : Interactable
{
    public GameObject PlayerGlock, GlockOnTable;
    public SpawnTargets TargetSpawner;
    protected override void Interact()
    {
        base.Interact();
        PlayerGlock.SetActive(true);
        TargetSpawner.EnableTargets();

        Destroy(GlockOnTable);
    }
}