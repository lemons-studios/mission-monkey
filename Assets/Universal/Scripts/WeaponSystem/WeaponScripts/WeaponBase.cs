using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WeaponBase : MonoBehaviour
{
    private Camera playerCamera;
    private PlayerInput playerInput;
    [Space]
    public float primaryCooldown = 0.25f;
    public float secondaryCooldown = 20f;
    public int weaponDamage = 10;
    [Space]
    public bool enableDebugMessages = false;
    private float primaryLastPerformed, secondaryLastPerformed;


    private void Start() 
    {
        playerCamera = Camera.main;

        playerInput = new PlayerInput();
        var onFootActions = playerInput.OnFoot; // Makes my life easier when writing method calls for actions
        onFootActions.Attack.performed += Attack;
        onFootActions.SecondaryAttack.performed += SecondaryAttack;

        playerInput.Enable();
    }

    protected virtual void Attack(InputAction.CallbackContext context)
    {
        if(Time.time - primaryLastPerformed < primaryCooldown)
        {
            // Only able to perform if the cooldown is over
            if(enableDebugMessages) Debug.Log("Remaining time until next use of attack: " + (Time.time + secondaryLastPerformed).ToString());
            return;
        }
        
        if(enableDebugMessages) Debug.Log("Performing regular attack");
        primaryLastPerformed = Time.time;
        GetComponent<WeaponEffectsManager>().TriggerWeaponEffects();    // The only line in here for now since both scripts will have sound effects and animations
    }

    protected virtual void SecondaryAttack(InputAction.CallbackContext context)
    {
        if(Time.time - secondaryLastPerformed < secondaryCooldown)
        {
            if(enableDebugMessages) Debug.Log("Remaining time until next use of attack: " + (Time.time + secondaryLastPerformed).ToString());
            return;
        }  
        if(enableDebugMessages) Debug.Log("Performing Secondary Attack"); 
        secondaryLastPerformed = Time.time;
        GetComponent<WeaponEffectsManager>().TriggerSecondaryWeaponEffects();
    }

    public Camera GetCamera()
    {
        return playerCamera;
    }

    private void OnDestroy() 
    {
        // Prevent the save system & Unity's scene loader from going crazy and spitting thousands of errors in the console
        playerInput.Disable();
    }
}
