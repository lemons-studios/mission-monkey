using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] WavesDuringCountdown;
    private int WaveCount = 0;

    public void TriggerWaveCoroutine()
    {
        StartCoroutine(EnemyWavesDuringEscapeSequence());
    }

    private IEnumerator EnemyWavesDuringEscapeSequence()
    {
        while (WaveCount < WavesDuringCountdown.Length)
        {
            yield return new WaitForSeconds(25);
            WavesDuringCountdown[WaveCount].SetActive(true);
            WaveCount += 1;
        }
    }
}