using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerInteractable : Interactable
{
    public PlayerHealth PlayerHealth;
    public int HealthHealedToPlayer, MaxUsagesPerDisable;


    protected override void Interact()
    {
        base.Interact();
        int CurrentUsageTimes = 0;
        if(CurrentUsageTimes <= MaxUsagesPerDisable)
        {
            CurrentUsageTimes += 1;
            PlayerHealth.HealPlayer(HealthHealedToPlayer);
            return;
        }
        else
        {
            gameObject.GetComponent<HealPlayerInteractable>().enabled = false;
        }
    }
}
