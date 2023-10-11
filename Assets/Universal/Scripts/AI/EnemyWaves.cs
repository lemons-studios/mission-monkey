using System.Collections;
using UnityEngine;

public abstract class EnemyWaves : MonoBehaviour
{
    public GameObject[] WaveGroups; // Would be a parent of all the enemies in the wave
    public float TimeBetweenWaveClearCheck = 0.15f;
    private int WaveCount;

    private void Start()
    {
        Mathf.Clamp(WaveCount, 0, WaveGroups.Length); 
    }

    public void StartWaves()
    {
        WaveGroups[0].SetActive(true);
        StartCoroutine(CheckEnemiesInWave());
    }

    private IEnumerator CheckEnemiesInWave()
    {
        yield return new WaitForSeconds(TimeBetweenWaveClearCheck);

        if (WaveGroups[WaveCount].transform.childCount == 0)
        {
            WaveCount++;
            WaveGroups[WaveCount].SetActive(true);
        }

        if(WaveCount == WaveGroups.Length)
        {
            OnFinalWaveComplete();
            StopCoroutine(CheckEnemiesInWave());
        }
    }

    protected virtual void OnFinalWaveComplete()
    {
        Debug.Log("Final Wave Complete!");
        gameObject.GetComponent<EnemyWaves>().enabled = false;
    }
}