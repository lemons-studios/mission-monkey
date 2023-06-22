public class HealInteractable : Interactable
{
    protected override void Interact()
    {
        PlayerHealth.healthHealed = 20f;
        PlayerHealth.healedHealth = true;
        PlayerHealth.HealPlayer();
    }
}
