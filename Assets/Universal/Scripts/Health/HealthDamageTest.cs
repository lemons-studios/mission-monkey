using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamageTest : Interactable
{
    protected override void Interact()
    {
        DamageInfo.damageTaken = 20;
        DamageInfo.dealtDamage = true;
    }
}