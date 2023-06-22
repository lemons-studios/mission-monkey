using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToScene : Interactable
{
    public int SceneNumber;
    protected override void Interact()
    {
        SceneManager.LoadScene(SceneNumber);
    }
}
