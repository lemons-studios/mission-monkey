using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetTracker : MonoBehaviour
{
    public int numberOfTargetsLeft;
    public TMP_Text targetsLeftText;

    public string nextLevelName;


    // Update is called once per frame
    void Update()
    {
        // Keep track of # of collectables left
        numberOfTargetsLeft = transform.childCount-1;
        targetsLeftText.text = "Targets Left: " + numberOfTargetsLeft;

        // Process end state (when all collectables are collected)!
        if (numberOfTargetsLeft <= 0)
        {
            ProcessEndOfGame();
        }
    }

    void ProcessEndOfGame()
    {
        if(nextLevelName != "")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
        }

    }
}
