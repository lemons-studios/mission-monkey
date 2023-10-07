using UnityEngine;

public class EquipGlock : Interactable
{
    public GameObject PlayerGlock, GlockOnTable, GunArm;

    protected override void Interact()
    {
        base.Interact();
        PlayerGlock.SetActive(true);
        // GunArm.SetActive(true);

        Destroy(GlockOnTable);
        Destroy(gameObject);
    }
}