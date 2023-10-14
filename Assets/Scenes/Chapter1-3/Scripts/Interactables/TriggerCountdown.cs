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
    public GameObject EscapePodSeatInteractable;

    protected override void Interact()
    {
        base.Interact();
        StartCoroutine(CountdownDisplayUpdate());
        MonkeyEscape.TriggerEscapeCoroutine();
        promptMessage = string.Empty;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private IEnumerator CountdownDisplayUpdate()
    {
        while (CountdownTime >= 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(CountdownTime);
            string CountdownTimeToString = timeSpan.ToString(@"mm/ss");
            CountdownUGUI.text = "Time until all monkeys board escape pods: " + CountdownTimeToString;
            CountdownTime -= 1;
            yield return new WaitForSeconds(1);
        }
        while (CountdownTime == 0)
        {
            CountdownUGUI.text = "All other monkeys have escaped! board your escape pod now!";
        }
    }
}