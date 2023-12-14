using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleElevator : Interactable
{
    public PlayerMotor PlayerMotor;
    protected override void Interact()
    {
        base.Interact();
        gameObject.GetComponentInParent<Animator>().SetBool("PlayerInElevator", true);
        gameObject.layer = LayerMask.NameToLayer("Default");
        PlayerMotor.sprintSpeed = 0;
        PlayerMotor.speed = 0;
    }
}
