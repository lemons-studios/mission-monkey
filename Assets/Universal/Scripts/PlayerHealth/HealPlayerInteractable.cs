public class HealPlayerInteractable : Interactable
{
    public PlayerHealth PlayerHealth;
    public int HealthHealedToPlayer, MaxUsagesPerDisable;
    private int CurrentUsageTimes;

    protected override void Interact()
    {
        base.Interact();
        
        if (CurrentUsageTimes >= MaxUsagesPerDisable)
        {
            gameObject.GetComponent<HealPlayerInteractable>().enabled = false;
            return;
        }
        CurrentUsageTimes += 1;
        PlayerHealth.HealPlayer(HealthHealedToPlayer);
    }
}
