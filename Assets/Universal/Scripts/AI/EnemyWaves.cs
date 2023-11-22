using System.Linq;
using UnityEngine;

public abstract class EnemyWaves : MonoBehaviour
{
    public GameObject[] WaveGroups; // Would be a parent of all the enemies in the wave
    public float TimeBetweenWaveClearCheck = 0.15f;
    private int WaveCount, LastWave;

    public void StartWaves()
    {
        WaveGroups[0].SetActive(true);
    }

    private void Update()
    {
        if (WaveCount != WaveGroups.Length)
        {
            if (WaveGroups[WaveCount].transform.childCount == 0) // There will be one error after the last wave has been cleared and that's just because I suck at programming
            {
                WaveCount++;
                Debug.Log("Spawning Next Wave");
                WaveGroups[WaveCount].SetActive(true);
            }
            return;
        }
        else OnFinalWaveComplete();
    }

    protected virtual void OnFinalWaveComplete()
    {
        Debug.Log("Final Wave Complete!");
        gameObject.GetComponent<EnemyWaves>().enabled = false;
    }
}