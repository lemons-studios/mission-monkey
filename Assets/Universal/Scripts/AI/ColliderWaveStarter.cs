using UnityEngine;

public class ColliderWaveStarter : EnemyWaves
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggerd");
        StartWaves();
    }

    protected override void OnFinalWaveComplete()
    {

        base.OnFinalWaveComplete();
    }
}