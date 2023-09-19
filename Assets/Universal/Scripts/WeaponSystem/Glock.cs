using UnityEngine.InputSystem;

public class Glock : AttackHandler
{
    private void Awake()
    {

    }
    protected override void Attack()
    {
        base.Attack();
        InstantiateBulletProjectile();
        // AttackAnim.Play();
    }

    protected override void AlternateAttack(InputAction.CallbackContext context)
    {
        base.AlternateAttack(context);
        // SpecialAttackAnim.Play();
    }
}
