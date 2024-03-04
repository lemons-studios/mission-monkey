using LemonStudios.CsExtensions;
using UnityEngine;

public class WeaponEffectsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound, secondaryAttackSound, reloadSound;
    public Animator weaponAnimations;

    public void TriggerWeaponEffects()
    {
        if (!LemonGameUtils.IsGamePaused())
        {
            if(audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound);
            }
            if(weaponAnimations != null)
            {
                // TODO: Weapon Animations and scripting them into the system
            }
        }
    }

    public void TriggerSecondaryWeaponEffects()
    {
        if (!LemonGameUtils.IsGamePaused())
        {
            if(audioSource != null && secondaryAttackSound != null)
            {
                audioSource.PlayOneShot(secondaryAttackSound);
            }
            if(weaponAnimations != null)
            {
                
            }
        }
    }

    public void TriggerReloadEffects()
    {
        if (!LemonGameUtils.IsGamePaused())
        {
            if (audioSource != null && reloadSound != null)
            {
                audioSource.PlayOneShot(reloadSound);
            }
        }
    }
}
