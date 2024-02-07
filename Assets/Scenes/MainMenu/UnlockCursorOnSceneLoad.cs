using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursorOnSceneLoad : MonoBehaviour
{
    private void OnEnable() 
    {
        Cursor.lockState = CursorLockMode.None;    
    }
}
