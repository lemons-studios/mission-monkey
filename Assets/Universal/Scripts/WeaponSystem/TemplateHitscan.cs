using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemplateHitscan : MonoBehaviour
{
    public float FireRate;
    public float reloadTime;
    public float MaxRange;
    public GameObject WeaponFirePoint;
    public Ray ray;
}
