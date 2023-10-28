using UnityEngine;

public class MobileControls : MonoBehaviour
{
    private bool IsOnMobile()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            return true;
        }
        else return false;
    }
    public GameObject MobileControlsUI;
    


    private void Start()
    {
        if (IsOnMobile())
        {
            MobileControlsUI.SetActive(true);
        }
    }
}