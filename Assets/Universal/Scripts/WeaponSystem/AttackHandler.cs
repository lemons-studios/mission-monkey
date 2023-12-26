
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AttackHandler : MonoBehaviour
{
    public float ProjectileDestroyTime, AttackCooldown, SpecialAttackCooldown;
    public int BulletsPerBurstShot, BulletSpeed;
    public float WeaponDamage;
    private bool IsInputHeld;

    public GameObject BulletProjectile;
    public Transform FirePoint;
    public PlayerInput Input;
    // public Animation AttackAnim, SpecialAttackAnim; /* (For 0.4.0) */ 

    private Camera Camera;
    private Ray BulletRay;
    private Coroutine clickHeldRoutine;

    public void Start()
    {
        Input = new PlayerInput();
        Input.OnFoot.Attack.started += OnAttackStarted;
        Input.OnFoot.Attack.canceled += OnAttackCanceled;

        Input.Enable();
        Camera = GetComponentInParent<Camera>();
    }

    public void OnAttackStarted(InputAction.CallbackContext context)
    {
        IsInputHeld = true;
        Attack(); // The idea behind this is that spam clicking would result in a faster bullet fire rate if the cooldown for hold clicks is longer than needing to spam click

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
            // Attack after a specified wait time that is decided upon in the scripts that inheirt this class
            Attack();
            yield return new WaitForSeconds(AttackCooldown);
        }
    }

    protected virtual void Attack()
    {
        if (gameObject.GetComponentInParent<PlayerHealth>().Health >= 1 && Time.timeScale >= 1)
        {
            if (BulletProjectile != null)
            {
                InstantiateBulletProjectile(FirePoint);
            }
            else Debug.LogError("GameObject 'BulletProjectile' is null!");

            RaycastHit hit;
            BulletRay = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(BulletRay, out hit))
            {
                // Debug.DrawRay(Camera.transform.position, transform.forward * 15, Color.red);
                if (hit.collider.CompareTag("WeaponInteractable"))
                {
                    // Create a variable for the GameObject the projectile hit
                    var WeaponInteractObject = hit.collider.gameObject;

                    // Get the Weapon Interaction comonent inside of the weapon interactable
                    WeaponInteract Interaction = WeaponInteractObject.GetComponent<WeaponInteract>();
                    Interaction.TriggerInteract();
                }

                else if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    // Debug.Log("Hit an Enemy!");
                    if (hit.collider.GetComponentInParent<EnemyAIHealth>() != null)
                    {
                        var HitEnemyHealth = hit.collider.gameObject.GetComponentInParent<EnemyAIHealth>();
                        HitEnemyHealth.DamageAI(WeaponDamage);
                        Debug.Log("Health remaining on enemy: " + HitEnemyHealth.GetAIHealth());
                    }
                }
            }
        }
    }

    private void InstantiateBulletProjectile(Transform point)
    {
        // Stolen code from 0.2 (it works good enough)

        // Creates a copy of the BulletProjectile GameObject and then adds a force to the rigidbody component after creating the copy (Again, all of these variables would be set by the classes that inherit this script)
        var CurrentProjectile = Instantiate(BulletProjectile, point.position, FirePoint.transform.rotation) as GameObject;

        CurrentProjectile.SetActive(true);
        CurrentProjectile.GetComponent<Rigidbody>().velocity = point.transform.forward * BulletSpeed;
    }

    protected virtual void AlternateAttack(InputAction.CallbackContext context)
    {
        // Empty since no base alternate attack stuff is in here yet (most likely to change once I get to programming this in for 0.4)
    }
}