using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToWaveCounter : MonoBehaviour
{

    public GameObject EnemyParent;
    public static bool isEnemyDead;
    public void Update()
    {
        if (EnemyParent.GetComponent<AiHealth>().aiHealth <= 0)
        {
            ComputerCaptcha.EnemiesClearedOnWave++;
            Destroy(EnemyParent);
        }
    }
}
