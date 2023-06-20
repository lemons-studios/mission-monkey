using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingStandInteractable : Interactable
{
    public GameObject interactableParent;
    public GameObject[] healthPacks;
    private int timesHealed = 0;
    protected override void Interact()
    {
        PlayerHealth.healedHealth = true;
        PlayerHealth.healthHealed = 15f;
        PlayerHealth.HealPlayer();
        Destroy(healthPacks[Random.Range(0,3)]);
        timesHealed++;
        if(timesHealed == 3) {
            Destroy(interactableParent);
        }
    }
}
