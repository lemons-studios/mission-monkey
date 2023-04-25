using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDamageTest : Interactable
{
    protected override void Interact()
    {
        PlayerHealth.damageTaken = 20;
        PlayerHealth.dealtDamage = true;
    }
}