using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePodLeave : Interactable
{
    public GameObject Player, EscapePodSeat;
    public Animator EscapePodAnimator;
    private bool Interacted = false;
    protected override void Interact()
    {
        base.Interact();
        Interacted = true;
        EscapePodAnimator.SetBool("MonkeyInEscapePod", true);
        promptMessage = string.Empty;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void Update()
    {
        if (Interacted)
        {
            Player.transform.position = EscapePodSeat.transform.position;
            StartCoroutine(WaituntilSceneLoad());
        }
    }

    private IEnumerator WaituntilSceneLoad()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}