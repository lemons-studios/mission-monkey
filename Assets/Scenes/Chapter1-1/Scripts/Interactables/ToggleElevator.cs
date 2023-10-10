using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleElevator : Interactable
{
    public PlayerMotor PlayerMotor;
    protected override void Interact()
    {
        base.Interact();
        gameObject.GetComponent<Animator>().SetBool("PlayerInElevator", true);
        gameObject.layer = LayerMask.NameToLayer("Default");
        PlayerMotor.enabled = false;
    }

    IEnumerator WaitUntilLoadScene()
    {
        
        yield return new WaitForSeconds(3.25f);
        PlayerMotor.enabled = true;
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
