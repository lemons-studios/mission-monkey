using UnityEngine;
using System;

public class DoorOpener2 : Interactable
{
    [SerializeField]
    public GameObject door;
    private bool DoorOpen;

    protected override void Interact()
    {
        DoorOpen = !DoorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", DoorOpen);
    }
}