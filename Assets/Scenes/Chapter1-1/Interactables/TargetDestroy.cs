using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : WeaponInteract
{
    public override void TriggerInteract()
    {
        base.TriggerInteract();
        TargetSpawns.NumberOfTargetsDestroyed++;
        Destroy(gameObject);
    }
}
