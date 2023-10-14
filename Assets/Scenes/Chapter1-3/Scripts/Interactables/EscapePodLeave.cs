using System.Collections;
using UnityEngine;

public class EscapePodLeave : Interactable
{
    public GameObject Player, EscapePodSeat;
    public Animator EscapePodAnimator;

    protected override void Interact()
    {
        base.Interact();
        StartCoroutine(TiePlayerToEscPodLocation());
        EscapePodAnimator.SetBool("MonkeyInEscapePod", true);
        promptMessage = string.Empty;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator TiePlayerToEscPodLocation()
    {
        while(true)
        {
            Player.transform.position = EscapePodSeat.transform.position;
        }
    }
}
