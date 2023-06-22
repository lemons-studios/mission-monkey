using UnityEngine;
using TMPro;
using System;
using UnityEngine.Audio;

public class HoldThePointInteractable : Interactable
{
    public GameObject[] Monkeys;
    public GameObject[] Wave1, Wave2, Wave3, Wave4, Wave5, Wave6;
    public GameObject LeaveInteractable;
    public Light LeaveEscapePodLight;
    public TextMeshProUGUI CountDown;
    public float TimeLeft = 150f;
    public float Roundedtime = 150f;
    int monkeyEnabler = 0;
    bool ButtonPushed = false;

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
            if (TimeLeft <= 0)
            {
                CountDown.text = "All the Monkeys Have Boarded. Escape Before This Space Station Blows Up!";
                LeaveInteractable.gameObject.SetActive(true);
                LeaveEscapePodLight.gameObject.SetActive(true);
            }
            if (Roundedtime == 130 & monkeyEnabler == 0|| Roundedtime == 105 & monkeyEnabler == 1 || Roundedtime == 80 & monkeyEnabler == 2 || Roundedtime == 55 & monkeyEnabler == 3 || Roundedtime == 30 & monkeyEnabler == 4|| Roundedtime == 20 & monkeyEnabler == 5 )
            {
                SpawnWave();
            }
        }
    }
    void SpawnWave()
    {
        
        if (monkeyEnabler == 0)
        {
            for (int i = 0; i < Wave1.Length; i++)
            {
                Wave1[i].SetActive(true);
            }
        }
        else if (monkeyEnabler == 1)
        {
            for (int i = 0; i < Wave2.Length; i++)
            {
                Wave2[i].SetActive(true);
            }
        }
        else if (monkeyEnabler == 2)
        {
            for (int i = 0; i < Wave3.Length; i++)
            {
                Wave3[i].SetActive(true);
            }
        }
        else if (monkeyEnabler == 3)
        {
            for (int i = 0; i < Wave4.Length; i++)
            {
                Wave4[i].SetActive(true);
            }
        }
        else if (monkeyEnabler == 4)
        {
            for (int i = 0; i < Wave5.Length; i++)
            {
                Wave5[i].SetActive(true);
            }
        }
        else if (monkeyEnabler == 5)
        {
            for (int i = 0; i < Wave6.Length; i++)
            {
                Wave6[i].SetActive(true);
            }
        }
        Monkeys[monkeyEnabler].SetActive(true);
        monkeyEnabler++;
    }
}
