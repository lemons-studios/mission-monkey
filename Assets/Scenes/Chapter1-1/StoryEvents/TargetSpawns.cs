using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawns : MonoBehaviour
{
    public GameObject BarrelPortal, Barrel;
    private float moveCheck = 0;
    public static float NumberOfTargetsDestroyed = 0;
    public static bool hasGunBeenPickedUp = false;
    public bool areAllTargetsDestroyed = false;

    public void Update()
    {
        Vector3 barrelCurrentpos = Barrel.transform.position;
        Vector3 BarrelPortalPos = new Vector3(barrelCurrentpos.x, barrelCurrentpos.y + 2, barrelCurrentpos.z);

        if (NumberOfTargetsDestroyed >= 3)
        {
            areAllTargetsDestroyed = true;
        }

        if (areAllTargetsDestroyed == true & NumberOfTargetsDestroyed >= 3 & moveCheck <= 0)
        {
            Barrel.transform.position = BarrelPortalPos;
            moveCheck++;
        }
    }

}