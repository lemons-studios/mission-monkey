using UnityEngine;
using LemonStudios.CsExtensions;

public class SetMouseSettings : MonoBehaviour
{
    private PlayerCamera playerCamera;
    public Camera mainCamera;
    private void Start()
    {
        if(!LemonStudiosCsExtensions.IsOnMainMenu())
        {
            playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCamera>();
        }
    }

    public void SetMS(int newSens)
    {
        if(LemonStudiosCsExtensions.IsOnMainMenu())
        {
            PlayerPrefs.SetInt("MouseSensitivity", newSens);
            return;
        }
        else
        {
            playerCamera.SetSensitivity(newSens);
        }
    }

    public void SetFov(int newFieldOfView)
    {
        mainCamera.fieldOfView = newFieldOfView;
        PlayerPrefs.SetInt("FieldOfView", newFieldOfView);
    }
}
