using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventDebug : Interactable
{
    private bool EventTriggered;
    public GameObject PrisonBars;
    protected override void Interact()
    {
        EventTriggered = !EventTriggered;
        PrisonBars.GetComponent<Animator>().SetBool("BarsExplodeEventTriggered", EventTriggered);
    }
}