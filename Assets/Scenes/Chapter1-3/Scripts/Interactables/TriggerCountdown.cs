using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TriggerCountdown : Interactable
{
    private float CountdownTime = 150f;
    public TextMeshProUGUI CountdownUGUI;
    public MonkeyEscape MonkeyEscape;
    public EnemySpawner Chapter1_3EnemySpawner;
    public GameObject EscapePodSeatInteractable, CorrectEscapePodLight, EscapePodBayCollider;

    protected override void Interact()
    {
        base.Interact();
        StartCoroutine(CountdownDisplayUpdate());
        MonkeyEscape.TriggerEscapeCoroutine();
        Chapter1_3EnemySpawner.TriggerWaveCoroutine();
        promptMessage = string.Empty;
        CountdownUGUI.gameObject.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    private void Update()
    {
        if(CountdownTime == 0)
        {
            EscapePodBayCollider.GetComponent<BoxCollider>().enabled = false;
            CorrectEscapePodLight.SetActive(true);
            CountdownUGUI.text = "All other monkeys have escaped! board your escape pod now!";
            EscapePodSeatInteractable.GetComponent<BoxCollider>().enabled = true;
        }
    }
    private IEnumerator CountdownDisplayUpdate()
    {
        while (CountdownTime > 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(CountdownTime);
            string CountdownTimeToString = timeSpan.ToString(@"mm\:ss");
            CountdownUGUI.text = "Time until all monkeys board escape pods: " + CountdownTimeToString;
            CountdownTime -= 1;
            yield return new WaitForSeconds(1);
        }
    }
}