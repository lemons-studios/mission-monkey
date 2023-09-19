using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AttackHandler : MonoBehaviour
{
    public float WeaponDamage, BulletsPerBurstShot, ProjectileDestroyTime, TimeBetweenShots, TimeBetweenAttacks, BulletRange;
    public bool IsInputHeld;
    public LayerMask EnemyMask;
    public GameObject FirePoint, BulletProjectile;
    public PlayerInput Input;
    // public Animation AttackAnim, SpecialAttackAnim; /// For 0.4.0 
    
    public Coroutine clickHeldRoutine;

    public void Start()
    {
        Input = new PlayerInput();
        Input.OnFoot.Attack.started += OnAttackStarted;
        Input.OnFoot.Attack.canceled += OnAttackCanceled;
        Input.OnFoot.SpecialAttack.performed += AlternateAttack;
        Input.Enable();
    }

    public void OnAttackStarted(InputAction.CallbackContext context)
    {
        IsInputHeld = true;
        Debug.Log("Attack action started");
        if (clickHeldRoutine == null)
        {
            clickHeldRoutine = StartCoroutine(ClickHeldRoutine());
        }
    }

    public void OnAttackCanceled(InputAction.CallbackContext context)
    {
        IsInputHeld = false;
        Debug.Log("Attack action canceled");
        if (clickHeldRoutine != null)
        {
            StopCoroutine(clickHeldRoutine);
            clickHeldRoutine = null;
        }
    }

    public IEnumerator ClickHeldRoutine()
    {
        while (IsInputHeld)
        {
            Attack();
            yield return new WaitForSeconds(TimeBetweenShots);
        }
    }

    public void InstantiateBulletProjectile()
    {

    }

    protected virtual void Attack()
    {
        // No code, as these methods will be inherited by other scripts which will contain actual code
    }

    protected virtual void AlternateAttack(InputAction.CallbackContext context)
    {
        // Read Line 62
    }
}
