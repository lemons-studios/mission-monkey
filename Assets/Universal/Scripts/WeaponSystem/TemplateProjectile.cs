using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class TemplateProjectile : MonoBehaviour
{
    public float FireRate;
    public float ProjectileSpeed;
    public GameObject ShootPoint;
    public float LoadTime;
    public LayerMask IsEnemy;
    public PlayerInput Input;
    public PlayerMotor Motor;
    
    protected virtual void start() {
        Input = GetComponent<PlayerInput>();
        Motor = GetComponent<PlayerMotor>();
    }
}
