using System.Collections;
using UnityEngine;

public class MonkeyEscape : MonoBehaviour
{
    public GameObject[] EscapingMonkeys;
    private int WhichEscapePod = 0;

    public void TriggerEscapeCoroutine()
    {
        StartCoroutine(ProgressiveMonkeyEscape());
    }

    // After a certain amount of time, enable a monkey gameobject from the array and get the escape pod it is in to trigger the exit animation
    public IEnumerator ProgressiveMonkeyEscape()
    {
        while (WhichEscapePod <= EscapingMonkeys.Length)
        {
            EscapingMonkeys[WhichEscapePod].SetActive(true);
            EscapingMonkeys[WhichEscapePod].GetComponentInParent<Animator>().SetBool("MonkeyInEscapePod", true);
            WhichEscapePod += 1;

            yield return new WaitForSeconds(25);
        }
    }
}