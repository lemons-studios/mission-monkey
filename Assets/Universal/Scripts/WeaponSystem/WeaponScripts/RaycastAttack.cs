using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastAttack : WeaponBase 
{
    protected override void Attack(InputAction.CallbackContext context)
    {
        base.Attack(context);

        // Raycasts are considerably more simple than AoE attacks.
        // Fire a raycast and check if it hit something. Raycast is fired through the player Camera
        Ray attackRay = GetCamera().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if(Physics.Raycast(attackRay, out RaycastHit hit))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                if(enableDebugMessages) Debug.Log("Hit GameObject is an enemy");
                hit.collider.GetComponent<EnemyHealth>().DamageAI(weaponDamage);
            }
            else if(hit.collider.CompareTag("WeaponInteractable"))
            {
                if(enableDebugMessages) Debug.Log("Hit GameObject is labeled as a Weapon Interactable");
                hit.collider.GetComponent<WeaponInteraction>().PerformWeaponInteraction();
            }
        }
    }
}
