using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewElevatorEventInteraction : Interactable
{
    public GameObject NewElevator;
    public GameObject Player;
    public bool isEventTriggered;

    protected override void Interact()
    {
        isEventTriggered = !isEventTriggered;
        NewElevator.GetComponent<Animator>().SetBool("IsInteractedWith", isEventTriggered);
        Player.GetComponent<PlayerMotor>().speed = 0f;
    }
}
