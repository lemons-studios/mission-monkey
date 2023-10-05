using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AttackHandler : MonoBehaviour
{
    public Camera Camera;
    public float ProjectileDestroyTime, TimeBetweenShots, TimeBetweenAttacks, BulletRange;
    public int WeaponDamage, BulletsPerBurstShot;
    public bool IsInputHeld;
    public LayerMask EnemyMask;
    public GameObject FirePoint, BulletProjectile;
    public PlayerInput Input;
    // public Animation AttackAnim, SpecialAttackAnim; /// For 0.4.0 
    private Ray BulletRay;
    public Coroutine clickHeldRoutine;

    private Vector3 BulletDestination;

    public void Start()
    {
        Input = new PlayerInput();
        Input.OnFoot.Attack.started += OnAttackStarted;
        Input.OnFoot.Attack.canceled += OnAttackCanceled;
        Input.OnFoot.SpecialAttack.performed += AlternateAttack;
        Input.Enable();

        Camera = GetComponentInParent<Camera>();
    }

    public void OnAttackStarted(InputAction.CallbackContext context)
    {
        // Attack();
        IsInputHeld = true;
        // Debug.Log("Attack action started");
        if (clickHeldRoutine == null)
        {
            clickHeldRoutine = StartCoroutine(ClickHeldRoutine());
        }
    }

    public void OnAttackCanceled(InputAction.CallbackContext context)
    {
        IsInputHeld = false;
        // Debug.Log("Attack action canceled");
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

    protected virtual void Attack()
    {
        if (!PlayerDeathController.isDead)
        {
            RaycastHit hit;
            BulletRay = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(BulletRay, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider.gameObject.CompareTag("WeaponInteractable"))
                {
                    // Debug.Log("Hit a weapon interactable!");

                    // Create a variable for the GameObject the projectile hit
                    var WeaponInteractObject = hit.collider.gameObject;
                    // Get the Weapon Interaction comonent inside of the weapon interactable
                    WeaponInteract Interaction = WeaponInteractObject.GetComponent<WeaponInteract>();

                    Interaction.TriggerInteract();
                }

                else if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    var HitEnemyHealth = hit.collider.gameObject.GetComponentInParent<AIHealth>();
                    HitEnemyHealth.HitPoints = HitEnemyHealth.HitPoints - WeaponDamage * Random.Range(2.0f, 0.5f);
                }
            }
        }
    }

    protected virtual void AlternateAttack(InputAction.CallbackContext context)
    {

    }
}
