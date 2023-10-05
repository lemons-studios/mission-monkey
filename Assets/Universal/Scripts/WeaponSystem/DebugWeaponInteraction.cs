using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugWeaponInteraction : WeaponInteract
{
    
    public override void TriggerInteract()
    {
        /// Debug.Log("Hit a Weapon Interactable!");
        base.TriggerInteract();
    }
}
