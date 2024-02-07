using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetNewVersionInfo : MonoBehaviour
{
    public TextMeshProUGUI newVersionTitle;


    private void Start()
    {
        newVersionTitle.text = "Welcome To " + Application.version + "!";
    }

    public void ViewOnGitHub()
    {
        Application.OpenURL("https://github.com/lemons-studios/mission-monkey/releases/latest");
    }
}
