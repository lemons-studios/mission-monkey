using UnityEngine;
using TMPro;
using System;
using UnityEngine.Audio;

public class HoldThePointInteractable : Interactable
{
    public GameObject[] Monkeys, Enemies;
    public GameObject LeaveInteractable;
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
            TimeSpan timeSpan = TimeSpan.FromSeconds(TimeLeft);
            string formattedTimeLeft = timeSpan.ToString(@"mm\:ss");
            CountDown.text = "Time Until All Monkeys Board: " + formattedTimeLeft;
            if(TimeLeft <= 0)
            {
                CountDown.text = "All the Monkeys Have Boarded. Escape Before This Space Station Blows Up!";
                LeaveInteractable.gameObject.SetActive(true);
            }
        }
    }
}
