using UnityEngine;

public class PickUpGlock : Interactable
{
    public GameObject GlockArm;
    public bool PickedUpGlock = false;

    protected override void Interact()
    {
        GlockArm.SetActive(true);
        PickedUpGlock = true;
        gameObject.SetActive(false);
    }
}
