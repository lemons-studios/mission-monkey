using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedBullet : MonoBehaviour
{
    public GameObject BulletProjectile, Player;

    public void Start()
    {
        Player = AiFoV.Player;
    }
    public void Update()
    {

    }
    public void FireProjectile()
    {
        float DistanceToPlayer = Vector3.Distance(BulletProjectile.transform.position, Player.transform.position);
        int DistanceFloored = Mathf.FloorToInt(DistanceToPlayer);
        if(DistanceFloored == 0) 
        { 

        }
    }
}
