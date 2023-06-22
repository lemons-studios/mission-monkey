using UnityEngine;
using TMPro;
using System;
using UnityEngine.Audio;

public class HoldThePointInteractable : Interactable
{
    public GameObject[] Monkeys;
    public GameObject LeaveInteractable;
    public Light LeaveEscapePodLight;
    public TextMeshProUGUI CountDown;
    public float TimeLeft = 150f;
    public float Roundedtime = 150f;
    int monkeyEnabler = 0;
    bool ButtonPushed = false;
    int escapeSequenceOver = 0;

    protected override void Interact()
    {
        ButtonPushed = true;
    }
    void Update()
    {
        if (ButtonPushed == true)
        {
            Roundedtime = Mathf.Round(TimeLeft);
            TimeLeft -= Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(TimeLeft);
            string formattedTimeLeft = timeSpan.ToString(@"mm\:ss");
            CountDown.text = "Time Until All Monkeys Board: " + formattedTimeLeft;
            if (TimeLeft <= 0 & escapeSequenceOver == 0)
            {
                CountDown.text = "All the Monkeys Have Boarded. Escape Before This Space Station Blows Up!";
                LeaveInteractable.gameObject.SetActive(true);
                LeaveEscapePodLight.gameObject.SetActive(true);
                escapeSequenceOver++;
            }
            if (Roundedtime == 130 & monkeyEnabler == 0 || Roundedtime == 105 & monkeyEnabler == 1 || Roundedtime == 80 & monkeyEnabler == 2 || Roundedtime == 55 & monkeyEnabler == 3 || Roundedtime == 30 & monkeyEnabler == 4 || Roundedtime == 20 & monkeyEnabler == 5)
            {
                SpawnWave();
            }
            if (Roundedtime == 130)
            {
                Chapter1_3Wave1.isWaveReady = true;
            }
            if (Roundedtime == 105)
            {
                Chapter1_3Wave2.isWaveReady = true;
            }
            if (Roundedtime == 80)
            {
                Chapter1_3Wave3.isWaveReady = true;
            }
            if (Roundedtime == 55)
            {
                Chapter1_3Wave4.isWaveReady = true;
            }
            if (Roundedtime == 30)
            {
                Chapter1_3Wave5.isWaveReady = true;
            }
            if (Roundedtime == 20)
            {
                Chapter1_3Wave6.isWaveReady = true;
            }
        }
    }
    void SpawnWave()
    {
        Monkeys[monkeyEnabler].SetActive(true);
        monkeyEnabler++;
    }

}