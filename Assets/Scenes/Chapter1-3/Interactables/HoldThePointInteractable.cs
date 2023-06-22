using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class HoldThePointInteractable : Interactable
{
    public GameObject[] Monkeys;
    public TextMeshProUGUI CountDown;
    public float TimeLeft = 150f;
    bool ButtonPushed = false;

    protected override void Interact()
    {
        ButtonPushed = true;
    }
    void Update()
    {
        if(ButtonPushed == true)
        {
            TimeLeft -= Time.deltaTime;
            CountDown.text = "Time Until Self-Destruct: " + TimeLeft.ToString("0");
            if(TimeLeft <= 0)
            {
                
            }
        }
    }
}
