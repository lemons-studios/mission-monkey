using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1_3Wave6 : MonoBehaviour
{
    public GameObject[] enemies;
    public static bool isWaveReady = false;

    public void SpawnEnemies()
    {

        if (isWaveReady == true)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].SetActive(true);
            }
        }

    }
}
