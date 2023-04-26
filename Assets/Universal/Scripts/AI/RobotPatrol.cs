using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPatrol : MonoBehaviour
{
    private bool rayHitPlayer = false;
    private bool isRayEnabled = false;
    private bool isPlayerSeen = false;
    public GameObject Player;
    
    void Start() 
    {
    }
    private void Shoot() 
    {

    }
    void FixedUpdate()
    {
        if(isPlayerSeen == true) 
        {
            Shoot();
        }
    }
}
