using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherOptions : MonoBehaviour
{
    public SaveData saveData;

    public void HideUI(GameObject uiToHide)
    {
        uiToHide.SetActive(false);
    }

    public void ShowUI(GameObject uiToShow)
    {
        uiToShow.SetActive(true);
    }
}
