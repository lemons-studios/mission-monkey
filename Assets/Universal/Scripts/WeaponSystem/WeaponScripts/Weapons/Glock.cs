using UnityEngine;
using UnityEngine.InputSystem;

public class Glock : RaycastAttack 
{
    protected override void SecondaryAttack(InputAction.CallbackContext context)
    {
        SecondaryAttack(context);
        Debug.Log("WIP");
    }
}
