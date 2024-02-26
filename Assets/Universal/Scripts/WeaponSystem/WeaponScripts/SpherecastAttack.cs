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
        // First, Shoot a racast towards the target the player is looking at. Then, spawn a SphereCast at that exact point
        // If an enemy or a WeaponInteractable is detected in the spherecast, damage them/perform the weapon interaction
        // REGARDLESS of weather they are seen or not (I cannot bother to add in wall detection right now, this shall do for a few months before I expand on it)

        Ray cameraRay = base.GetCamera().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(cameraRay, out hit, enemyAndInteractLayers))
        {
            Vector3 hitPoint = hit.point;
            Vector3 direction = transform.forward;
            RaycastHit[] sphereCastHits = Physics.SphereCastAll(hitPoint, sphereCastRadius, direction, sphereCastRadius, enemyAndInteractLayers);
            
            if(sphereCastHits.Length != 0)
            {
                int hitGameObjects = 0;
                for(int i = 0; i < sphereCastHits.Length; i++)
                {
                    if(sphereCastHits[i].collider.gameObject.CompareTag("Enemy"))
                    {
                        hit.collider.GetComponent<EnemyHealth>().DamageAI(base.weaponDamage);
                        hitGameObjects++;
                    }
                    else if(sphereCastHits[i].collider.gameObject.CompareTag("WeaponInteract"))
                    {
                        sphereCastHits[i].collider.GetComponent<WeaponInteraction>().PerformWeaponInteraction();
                        hitGameObjects++;
                    }
                }
                if(base.enableDebugMessages) Debug.Log("Hit " + hitGameObjects + " with AoE Attack");
            }
        }

        
    }
}
