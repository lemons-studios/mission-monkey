
using System.Collections;
using LemonStudios.CsExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class AttackHandler : MonoBehaviour
{
    public AudioClip regularAttackSoundEffect, specialAttackSoundEffect;
    public GameObject bulletProjectile;
    public Transform firePoint;

    private AudioSource weaponSfxSource;
    private Camera mainCamera;
    private Coroutine? clickHeldRoutine;
    private PlayerHealth playerHealth;
    private PlayerInput playerInput;
    private Ray bulletRay;

    public int bulletsPerBurst, bulletSpeed, baseWeaponDamage;
    public float attackCooldown, maxDamageIncrease, maxDamageReduction, projectileDestroyTime, secondaryAttackCooldown;
    public bool doesWeaponRandomiseDamage = true;
    public bool enableWeaponDebugFeatures = false;
    private bool isInputHeld;

    public void Start()
    {
        // Create Input Actions
        playerInput = new PlayerInput();
        var onFootAttack = playerInput.OnFoot.Attack;   // This is only here to shorten the next two lines
        onFootAttack.started += OnAttackStarted;
        onFootAttack.canceled += OnAttackCanceled;
        playerInput.Enable();

        // PlayerHealth is on the player GameObject
        playerHealth = GetComponentInParent<PlayerHealth>();

        // AudioSources for any weapon will be a child of that GameObject
        weaponSfxSource = GetComponentInChildren<AudioSource>();

        // This class was designed specifically for the usage with the player's camera (or the main camera)
        mainCamera = Camera.main;
    }

    public void OnAttackStarted(InputAction.CallbackContext context)
    {
        // Starts a coroutine that will constantly call WeaponAttack() while the input is being held
        isInputHeld = true;
        WeaponAttack(); // The idea behind this is that spam clicking would result in a faster bullet fire rate if the cooldown for hold clicks is longer than needing to spam click

        // Debug.Log("Attack action started");
        if (clickHeldRoutine == null)
        {
            clickHeldRoutine = StartCoroutine(ClickHeldRoutine());
        }
    }

    public void OnAttackCanceled(InputAction.CallbackContext context)
    {
        // Stops the coroutine when the player stops holding the fire button
        isInputHeld = false;
        // Debug.Log("Attack action canceled");

        if (clickHeldRoutine != null)
        {
            StopCoroutine(clickHeldRoutine);
            clickHeldRoutine = null;
        }
    }

    public IEnumerator ClickHeldRoutine()
    {
        while (isInputHeld)
        {
            // Attack after a specified wait time that is decided upon in the scripts that inheirt this class
            WeaponAttack();
            yield return new WaitForSeconds(attackCooldown);
        }
    }

    protected virtual void WeaponAttack()
    {
        if (CanPlayerAttack())
        {
            if (regularAttackSoundEffect != null)
            {
                weaponSfxSource.PlayOneShot(regularAttackSoundEffect);
            }

            if (bulletProjectile != null)
            {
                InstantiateBulletProjectile(firePoint);
            }
            else Debug.LogError("'BulletProjectile' is null!");

            bulletRay = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(bulletRay, out hit))
            {
                if(enableWeaponDebugFeatures)
                {
                    Debug.DrawRay(mainCamera.transform.position, transform.forward * 15, Color.red);
                    Debug.Log("Hit " + hit.collider.gameObject.name);
                }
                
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
                    EnemyHealth aiHealth = hit.collider.GetComponent<EnemyHealth>();
                    if (hit.collider.GetComponentInParent<EnemyHealth>() != null)
                    {
                        if (doesWeaponRandomiseDamage)
                        {
                            aiHealth.RandomAIDamage(baseWeaponDamage, 0.5f, 2.0f);   
                        }
                        else aiHealth.DamageAI(baseWeaponDamage);
                        return;
                    }
                    else Debug.LogError("Enemy does not have EnemyAIHealth Component!");
                }
            }
        }
    }

    private void InstantiateBulletProjectile(Transform point)
    {
        // Stolen code from 0.2 (it works good enough)
        // Creates a copy of the BulletProjectile GameObject and then adds a force to the rigidbody component after creating the copy (Again, all of these variables would be set by the classes that inherit this script)

        var CurrentProjectile = Instantiate(bulletProjectile, point.position, firePoint.transform.rotation) as GameObject;
        CurrentProjectile.SetActive(true);
        CurrentProjectile.GetComponent<Rigidbody>().velocity = point.transform.forward * bulletSpeed;
    }

    protected virtual void AlternateAttack(InputAction.CallbackContext context)
    {
        // WIP
        if (CanPlayerAttack())
        {
            if (specialAttackSoundEffect != null)
            {
                weaponSfxSource.PlayOneShot(specialAttackSoundEffect);
            }
        }

    }

    private bool CanPlayerAttack()
    {
        // The player shouldn't be able to attack if the game is paused or if they are dead
        if (playerHealth.GetHealth() >= 1 && !LemonGameUtils.IsGamePaused())
        {
            return true;
        }
        else return false;
    }

    private void OnDestroy()
    {
        playerInput.Disable();
    }
}
