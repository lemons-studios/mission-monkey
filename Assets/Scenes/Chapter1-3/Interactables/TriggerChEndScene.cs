using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerChEndScene : Interactable
{
    public GameObject InterctObj, EscapePod;
    public Animator animator;
    public string animationStateName;
    protected override void Interact()
    {
        TiePlayerToEscPod.InEscapePod = true;
        EscapePod.GetComponent<Animator>().SetBool("MonkeyInEscapePod", true);
        Destroy(InterctObj);
    }
    private bool IsAnimationFinished(Animator anim, string stateName)
    {
        // You can replace 0 with the appropriate layer index if you have multiple layers in your Animator
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName(stateName) && stateInfo.normalizedTime >= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
        if(IsAnimationFinished(animator, animationStateName))
        {
            SceneManager.LoadScene(0);
        }
    }
}
