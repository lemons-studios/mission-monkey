using UnityEngine.InputSystem;

public class Glock : AttackHandler
{
    protected override void Attack()
    {
        base.Attack();
    }

    public void InstantiateGlockProjectile()
    {

    }

    protected override void AlternateAttack(InputAction.CallbackContext context)
    {
        base.AlternateAttack(context);
        // SpecialAttackAnim.Play();
    }
}
