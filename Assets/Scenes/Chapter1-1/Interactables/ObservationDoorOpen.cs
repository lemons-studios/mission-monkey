using UnityEngine;

public class ObservationDoorOpen : Interactable
{
    [SerializeField]
    public GameObject ObvDoorAndSwitch;
    
    private bool IsActive;

    protected override void Interact()
    {
        IsActive = !IsActive;
        ObvDoorAndSwitch.GetComponent<Animator>().SetBool("IsActive", IsActive);
    }
}