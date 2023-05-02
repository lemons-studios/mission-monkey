using UnityEngine;

public class DoorOpener : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
