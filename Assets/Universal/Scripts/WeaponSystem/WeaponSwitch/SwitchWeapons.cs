using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchWeapons : MonoBehaviour 
{
    public GameObject[] weapons;
    PlayerInput playerInput = new PlayerInput();
    
    // TODO: Weapon Switching System
    private void Start() 
    {
        playerInput.OnFoot.SwitchWeapons.performed += SwitchToNextWeapon;
        playerInput.Enable();
    }    

    private void SwitchToNextWeapon(InputAction.CallbackContext context)
    {

    }

    private void OnDestroy() 
    {
        playerInput.Disable();    
    }
}