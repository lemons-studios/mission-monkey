using UnityEngine;
using UnityEngine.InputSystem;

public class CHeck : MonoBehaviour
{
    PlayerInput input = new PlayerInput();
    private void Start()
    {
        input.UI.Click.performed += LogInput;
        input.Enable();
    }

    private void LogInput(InputAction.CallbackContext context)
    {
        Debug.Log("Input received");
    }
}
