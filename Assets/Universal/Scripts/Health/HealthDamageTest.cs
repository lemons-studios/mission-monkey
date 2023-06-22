public class HealthDamageTest : Interactable
{
    protected override void Interact()
    {
        PlayerHealth.damageTaken = 20;
        PlayerHealth.dealtDamage = true;
        PlayerHealth.DamagePlayer();
    }
}