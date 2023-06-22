using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave2 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Wave2Enemies;
    public GameObject ScriptParent;
    public static bool IsPreviousWaveKilled;
    public bool areAllEnemiesKilled = true;
    bool hasEventTriggered = false;

    void Update()
    {
        for (int i = 0; i < Wave2Enemies.Length; i++)
        {
            if (Wave2Enemies[i] != null)
            {
                areAllEnemiesKilled = false;
                break;
            }
            else
            {
                Debug.Log("All Enemies Are KILLED");
                areAllEnemiesKilled = true;
            }
        }
        if(IsPreviousWaveKilled == true & hasEventTriggered == false)
        {
            SpawnEnemies();
            hasEventTriggered = true;
        }
        if(areAllEnemiesKilled == true)
        {
            SpawnWave3.IsPreviousWaveKilled = true;
            Destroy(ScriptParent);
        }
    }
    public void SpawnEnemies()
    {
        for(int i = 0; i < Wave2Enemies.Length; i++)
        {
            Wave2Enemies[i].SetActive(true);
        }
    }
}
