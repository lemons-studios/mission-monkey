using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave3 : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Wave3Enemies;
    public GameObject ScriptParent;
    public static bool IsPreviousWaveKilled;
    public bool areAllEnemiesKilled = true;
    bool hasEventTriggered = false;
    void Update()
    {
        for (int i = 0; i < Wave3Enemies.Length; i++)
        {
            if (Wave3Enemies[i] != null)
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
            OpenTestChamberDoor.isAllowedToOpen = true;
            Destroy(ScriptParent);
        }
    }
    public void SpawnEnemies()
    {
        for(int i = 0; i < Wave3Enemies.Length; i++)
        {
            Wave3Enemies[i].SetActive(true);
        }
    }
}
