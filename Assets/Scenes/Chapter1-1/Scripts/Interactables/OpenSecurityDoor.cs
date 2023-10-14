using UnityEngine;

public class OpenSecurityDoor : Interactable
{
    public Animator SecurityDoorAnimator;
    private bool IsDoorOpen = false;
    protected override void Interact()
    {
        base.Interact();
        IsDoorOpen = !IsDoorOpen;
        SecurityDoorAnimator.SetBool("SecurityDisabled", IsDoorOpen);
        gameObject.GetComponent<OpenSecurityDoor>().enabled = false;
    }
}