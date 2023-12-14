using UnityEngine;

public class OpenReactorDoor : Interactable
{
    public Animator DoorAnimator;
    private bool IsDoorOpen;
    public OpenReactorDoor OtherKeyboard;
    protected override void Interact()
    {
        base.Interact();
        IsDoorOpen = !IsDoorOpen;
        DoorAnimator.SetBool("IsOpen", IsDoorOpen);
        switch(IsDoorOpen)
        {
            case true:
                promptMessage = "Close Reactor Door";
                OtherKeyboard.promptMessage = promptMessage;
                break;
            case false:
                promptMessage = "Open Reactor Door";
                OtherKeyboard.promptMessage = promptMessage;
                break;
        }
    }

}