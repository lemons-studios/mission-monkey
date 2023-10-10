using UnityEngine;

public class OpenObservationDoor : Interactable
{
    private bool IsDoorOpen = false;

    protected override void Interact()
    {
        IsDoorOpen = !IsDoorOpen;
        if (IsDoorOpen)
        {
            promptMessage = "Close Observation Door";
        }
        else if(!IsDoorOpen)
        {
            promptMessage = "Open Observation Door";
        }

        gameObject.GetComponentInParent<Animator>().SetBool("IsDoorOpen", IsDoorOpen);
    }
}
