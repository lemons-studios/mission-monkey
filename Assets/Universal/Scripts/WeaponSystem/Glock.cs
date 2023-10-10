using UnityEngine;
using UnityEngine.InputSystem;

public class Glock : AttackHandler
{
    protected override void Attack()
    {
        base.Attack();
    }

    protected override void AlternateAttack(InputAction.CallbackContext context)
    {
        base.AlternateAttack(context);
        // SpecialAttackAnim.Play();
    }
}
