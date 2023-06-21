using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToWaveCounter : MonoBehaviour
{


    public GameObject HealthPack, Parent;
    public static bool isEnemyDead;
    private Vector3 HealthpackLocation;


    public void Update()
    {
        //EnemyParent.transform.position = HealthpackLocation;
        if (Parent.GetComponent<AiHealth>().aiHealth <= 0)
        {
            if (PlayerHealth.Health <= 45f)
            {
                //Instantiate(HealthPack, HealthpackLocation, Quaternion.identity);
            }

            ComputerCaptcha.EnemiesClearedOnWave++;
            Debug.Log("Enemy Killed! Count is now at " + ComputerCaptcha.EnemiesClearedOnWave);
            Destroy(Parent);
        }
    }
}
