using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToWaveCounter : MonoBehaviour
{
    public GameObject Parent;
    public void Update()
    {
        if(Parent.GetComponent<AiHealth>().aiHealth <= 0)
        {
            ComputerCaptcha.EnemiesClearedOnWave++;
            Debug.Log("Enemy Killed! Counter is Now at: " + ComputerCaptcha.EnemiesClearedOnWave);
        }
    }
}
