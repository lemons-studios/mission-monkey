using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteractable
{
    public void Interact() {
        Debug.Log("Door Opened (100% guys)");
    }
}
