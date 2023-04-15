using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string poromptMessage;
    
    public void BaseInteract() {
        Interact();
    }
    protected virtual void Interact() {
        //No code here, as it is a template for other scripts to overwrite
    }
}
