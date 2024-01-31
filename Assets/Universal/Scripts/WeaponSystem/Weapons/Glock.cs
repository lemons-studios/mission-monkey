using UnityEngine.InputSystem;

public class Glock : AttackHandler
{
    protected override void WeaponAttack()
    {
        base.WeaponAttack();
    }

    protected override void AlternateAttack(InputAction.CallbackContext context)
    {
        base.AlternateAttack(context);
        // SpecialAttackAnim.Play();
    }
}
