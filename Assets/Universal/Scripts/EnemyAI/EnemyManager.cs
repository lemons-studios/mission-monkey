using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemySight))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyHealth))]     // While this script won't deal with the health script (since does not have a need to deal with it), adding it with this script makes it the all-in-one AI creator script
[RequireComponent(typeof(EnemyNavigation))]
public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
