using UnityEngine;
using System;

public class SwitchAnim : Interactable
{
    [SerializeField]
    public GameObject switchObject;
    private bool SwitchPulled;

    protected override void Interact()
    {
        SwitchPulled = !SwitchPulled;
        switchObject.GetComponent<Animator>().SetBool("SwitchPulled", switchObject);
    }
}