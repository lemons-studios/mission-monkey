using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidBotAI : MonoBehaviour
{
    public GameObject fov;
    public GameObject BulletProjectile;
    public GameObject[] FirePoints;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(fov.GetComponent<FieldOfView>().canSeePlayer == true & !PlayerDeathController.isDead)
        {
            ShootPlayer();    
        }
    }
    private void ShootPlayer() 
    {
        for(int i = 0; i < FirePoints.Length; i++)
        {
            
        }
    }
}
