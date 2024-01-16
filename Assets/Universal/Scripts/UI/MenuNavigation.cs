using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public void HideMenu(GameObject menuToHide)
    {
        menuToHide.SetActive(false);
    }
    public void ShowMenu(GameObject menuToShow)
    {
        menuToShow.SetActive(true);
    }
}
