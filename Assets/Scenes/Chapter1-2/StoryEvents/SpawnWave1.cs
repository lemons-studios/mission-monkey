using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave1 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Wave1Enemies;
    public GameObject ScriptParent;
    public static bool isEventReady = false;
    public bool areAllEnemiesKilled = true;
    bool hasEventTriggered = false;

    void Update()
    {
        for (int i = 0; i < Wave1Enemies.Length; i++)
        {
            if (Wave1Enemies[i] != null)
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
        if(areAllEnemiesKilled == true)
        {
            SpawnWave2.IsPreviousWaveKilled = true;
            Destroy(ScriptParent);
        }
        if(isEventReady == true)
        {
            SpawnEnemies();
        }
    }
    public void SpawnEnemies()
    {
        for(int i = 0; i < Wave1Enemies.Length; i++)
        {
            Wave1Enemies[i].SetActive(true);
        }
    }
}
