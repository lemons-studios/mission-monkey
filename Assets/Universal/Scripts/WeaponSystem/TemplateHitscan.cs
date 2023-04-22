using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class TemplateHitscan : MonoBehaviour
{
    public float FireRate;
    public float reloadTime;
    public float MaxRange;
    public GameObject WeaponFirePoint;
    public LayerMask IsEnemy;
    public PlayerInput Input;

    protected virtual void start() {
        Input = GetComponent<PlayerInput>();
    }
}
