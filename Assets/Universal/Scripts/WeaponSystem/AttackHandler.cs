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
    // public Animation AttackAnim, SpecialAttackAnim; /*(For 0.4.0)*/ 

    private Camera Camera;
    private Ray BulletRay;
    private Coroutine clickHeldRoutine;
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

            RaycastHit hit;
            BulletRay = Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(BulletRay, out hit))
            {


                Debug.DrawRay(Camera.transform.position, transform.forward * 15, Color.red);


                if (hit.collider.CompareTag("WeaponInteractable"))
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
                    // Debug.Log("Hit an Enemy!");
                    if (hit.collider.GetComponentInParent<AIHealth>() != null)
                    {
                        var HitEnemyHealth = hit.collider.gameObject.GetComponentInParent<AIHealth>();
                        float UnroundedDamage = WeaponDamage * Random.Range(0.5f, 2.0f);

                        int RoundedDamage = Mathf.RoundToInt(UnroundedDamage);
                        HitEnemyHealth.HitPoints = HitEnemyHealth.HitPoints - RoundedDamage;

                        // Debug.Log("Damage Dealt: " + RoundedDamage);
                        if (HitEnemyHealth.HitPoints >= 0)
                        {
                            Debug.Log("Health Remaining: " + HitEnemyHealth.HitPoints);
                        }
                    }
                }
            }
        }
    }

    private void InstantiateBulletProjectile(Transform point)
    {
        // Stolen code from 0.2.0 (it works good enough)

        var CurrentProjectile = Instantiate(BulletProjectile, point.position, FirePoint.transform.rotation) as GameObject;

        CurrentProjectile.SetActive(true);
        CurrentProjectile.GetComponent<Rigidbody>().velocity = point.transform.forward * BulletSpeed;
    }

    protected virtual void AlternateAttack(InputAction.CallbackContext context)
    {

    }
}