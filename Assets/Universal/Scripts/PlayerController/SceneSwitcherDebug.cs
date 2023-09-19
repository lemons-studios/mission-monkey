using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcherDebug : MonoBehaviour
{
    public PlayerInput Input;

    private void Start()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();

        Input = new PlayerInput();
        Input.DevTools.SceneSwitchForward.performed += SceneSwitchForward;
        Input.DevTools.SceneSwitchBackward.performed += SceneSwitchBackward;
        Input.Enable();
    }

    public void SceneSwitchForward(InputAction.CallbackContext context)
    {
        
    }
    public void SceneSwitchBackward(InputAction.CallbackContext context)
    {

    }
    public void SceneSwitchGUI(InputAction.CallbackContext context)
    {
        // empty until the project needs it
    }
}
