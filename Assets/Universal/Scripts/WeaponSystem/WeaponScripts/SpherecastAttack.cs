using UnityEngine;
using UnityEngine.InputSystem;

public class SpherecastAttack : WeaponBase 
{
    private LayerMask enemyAndInteractLayers;
    public float sphereCastRadius = 5f;

    private void Start()
    {
        enemyAndInteractLayers = LayerMask.GetMask("Enemy", "WeaponInteractable", "Player");
    }

    protected override void Attack(InputAction.CallbackContext context)
    {
        base.Attack(context);

        // My approach to AoE attacks is similar to what is implemented in the EnemySight script.
        // First, Shoot a raycast towards the target the player is looking at. Then, spawn a SphereCast at that exact point
        // If an enemy or a WeaponInteractable is detected in the SphereCast, damage them/perform the weapon interaction
        // REGARDLESS of weather they are seen or not (I cannot bother to add in wall detection right now, this shall do for a few months before I expand on it)

        Ray cameraRay = GetCamera().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(cameraRay, out RaycastHit hit, enemyAndInteractLayers))
        {
            Vector3 hitPoint = hit.point;
            Vector3 direction = transform.forward;
            RaycastHit[] sphereCastHits = Physics.SphereCastAll(hitPoint, sphereCastRadius, direction, sphereCastRadius, enemyAndInteractLayers);
            if (sphereCastHits.Length == 0) return;
            
            int hitGameObjects = 0;
            foreach (var currentHit in sphereCastHits)
            {
                if(currentHit.collider.gameObject.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<EnemyHealth>().DamageAI(weaponDamage);
                    hitGameObjects++;
                }
                else if(currentHit.collider.gameObject.CompareTag("WeaponInteractable"))
                {
                    currentHit.collider.GetComponent<WeaponInteraction>().PerformWeaponInteraction();
                    hitGameObjects++;
                }
            }
            if(enableDebugMessages) Debug.Log("Hit " + hitGameObjects + " with AoE Attack");
        }
    }
}
