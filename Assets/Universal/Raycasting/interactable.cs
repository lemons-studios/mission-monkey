using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    //Message that will display when the player looks at an interactable object
    public string promptMessage; 
    public void BaseInteract() {
        Interact();
    }
    protected virtual void Interact() {

    }

}