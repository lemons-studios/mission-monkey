using LemonStudios.CsExtensions;
using UnityEngine;

public class WeaponEffectsManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSound, secondaryAttackSound;
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
}
