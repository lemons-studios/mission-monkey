using UnityEngine;

public class EquipGlock : Interactable
{
    public GameObject PlayerGlock, GlockOnTable;

    protected override void Interact()
    {
        base.Interact();
        PlayerGlock.SetActive(true);

        Destroy(GlockOnTable);
        Destroy(gameObject);
    }
}