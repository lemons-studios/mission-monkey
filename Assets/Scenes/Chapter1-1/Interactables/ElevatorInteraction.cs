using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ElevatorInteraction : Interactable
{
    public GameObject Elevator;
    public VideoPlayer ElevatorClipPlayer;
    private bool ElevatorEventTriggered;

    protected override void Interact()
    {
        Elevator.GetComponent<Animator>().SetBool("Triggered", ElevatorEventTriggered);
        if(!ElevatorClipPlayer.isPlaying)
        {
            ElevatorClipPlayer.Play();
        }
    }
}
