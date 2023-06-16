using UnityEngine;
public class DisableTurrets : Interactable
{
    public GameObject Turret;
    public GameObject EventTriggerObject;
    //public bool IsButtonPressed = false;

    protected override void Interact()
    {
            Turret.GetComponent<AiTurret>().enabled = false;
            Destroy(EventTriggerObject);
    }
}
