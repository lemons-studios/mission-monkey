using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePodLeave : Interactable
{
    public GameObject EscapePodSeat, escapePodCam;
    public GameObject[] ObjectsToDisable;

    public Animator EscapePodAnimator;
    
    protected override void Interact()
    {
        base.Interact();
        gameObject.GetComponent<BoxCollider>().enabled = false;
        promptMessage = string.Empty;
        PrepareEndScene();
    }

    private void PrepareEndScene()
    {
        escapePodCam.SetActive(true);
        foreach (GameObject obj in ObjectsToDisable)
        {
            obj.SetActive(false);
        }
        
        EscapePodAnimator.SetBool("MonkeyInEscapePod", true);
        StartCoroutine(WaituntilSceneLoad());
    }

    private IEnumerator WaituntilSceneLoad()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene("Credits");
    }
}