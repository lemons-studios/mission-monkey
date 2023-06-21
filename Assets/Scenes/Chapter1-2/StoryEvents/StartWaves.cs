using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaves : MonoBehaviour
{
    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnWave1.isEventReady = true;
        }
    }
}
