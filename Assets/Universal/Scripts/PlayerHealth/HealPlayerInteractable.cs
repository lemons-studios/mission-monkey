public class HealPlayerInteractable : Interactable
{
    public PlayerHealth PlayerHealth;
    public int HealthHealedToPlayer, MaxUsagesPerDisable;
    private int CurrentUsageTimes = 0;

    protected override void Interact()
    {
        base.Interact();
        CurrentUsageTimes += 1;
        PlayerHealth.HealPlayer(HealthHealedToPlayer);
    }
}