using UnityEngine;

public class TurretDisable : Interactable
{
    public GameObject DisabledTurret;
    public GameObject Turret;

    protected override void Interact()
    {
        DisabledTurret.SetActive(true);
        Turret.SetActive(false);
    }
}
