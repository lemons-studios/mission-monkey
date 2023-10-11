using UnityEngine;

public class StartWaveOnCollide : EnemyWaves
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        StartWaves();
    }
}