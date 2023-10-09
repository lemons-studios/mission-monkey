using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    StateManager stateManager;
    EnemyPatrol enemyPatrol;
    Follow follow;
    EnemyEyeSight enemyEyeSight;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GetComponent<StateManager>();
        enemyPatrol = GetComponentInChildren<EnemyPatrol>();
        follow = GetComponentInChildren<Follow>();
        enemyEyeSight = GetComponent<EnemyEyeSight>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyEyeSight.seePlayer == true)
        {
            stateManager.currentState = follow;
            follow.Search();

        }
        else
        {
         
        }
    }
}
