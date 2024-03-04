using System;
using System.Collections;
using LemonStudios.CsExtensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoAndReload : MonoBehaviour
{
    private Image ammoCountUI;
    private TextMeshProUGUI currentAmmoCountText;
    private WeaponBase weapon;
    private WeaponEffectsManager weaponEffects;
    private PlayerInput playerInput;
    
    private int maxAmmo;
    private int ammoInMag;


    private void Start()
    {
        // Attempt to find a Weapon component (Since all weapons inherit from WeaponBase, look for that component) and a weapon effects component
        try
        {
            weapon = GetComponent<WeaponBase>();
            weaponEffects = GetComponent<WeaponEffectsManager>();
        }
        catch (NullReferenceException e)
        {
            Debug.LogError("Error: One or more of the weapon system components not found on: " + gameObject.name + ". \nfull error: " + e);
        }
        
        // Set the current ammo count to be the max ammo amount at the start of the game
        // TODO: In future, replace ammo checking with a save system call
        maxAmmo = weapon.maxAmmo;
        ammoInMag = maxAmmo;
    }

    private void OnEnable()
    {
        // Get the ammo count UI image
        ammoCountUI = GameObject.FindGameObjectWithTag("AmmoCountUI").GetComponent<Image>();
        
        // Set Ammo count text using the just defined ammo count UI image
        currentAmmoCountText = ammoCountUI.GetComponentInChildren<TextMeshProUGUI>();
        
        // Initialize PlayerInput and bindings
        playerInput = new PlayerInput();
        playerInput.OnFoot.Attack.performed += ctx => UpdateAmmoCount();
        playerInput.OnFoot.Reload.performed += ctx => StartCoroutine(OnReload());
        playerInput.Enable();
        
        // Set the ammo count to be accurate in the scene
        currentAmmoCountText.text = ammoInMag + " / " + maxAmmo;
        
        // Finally, in the case that the weapon was enabled because the player switched to this weapon,
        // instantly set the fill percentage of the ammo count UI to what it's supposed to be
        if (Math.Abs(ammoCountUI.fillAmount - (float) ammoInMag / maxAmmo) > 0.0001f)
        {
            ammoCountUI.fillAmount = (float) ammoInMag / maxAmmo;
        }
    }
    
    private void UpdateAmmoCount()
    {
        if (!IsMagEmpty())
        {
            ammoInMag -= 1;
            currentAmmoCountText.text = ammoInMag + " / " + maxAmmo;
            float targetFill = (float)ammoInMag / maxAmmo;
            
            StartCoroutine(LemonUIUtils.SmoothlyUpdateFillUI(ammoCountUI, targetFill));
        }
    }

    private IEnumerator OnReload()
    {
        weapon.setReloadState(true);
        weaponEffects.TriggerReloadEffects();
        yield return new WaitForSeconds(weapon.reloadTime);
        weapon.setReloadState(false);
    }

    private bool IsMagEmpty()
    {
        // Only used once, 100% did not need to be separated. Just didn't like the clutter when writing the method
        return ammoInMag <= 0;
    }
    
    private void OnDestroy()
    {
        // Destroy every reference of a variable or else unity will scream at me when anything related to scene loading happens
        playerInput.Disable();
    }
}
