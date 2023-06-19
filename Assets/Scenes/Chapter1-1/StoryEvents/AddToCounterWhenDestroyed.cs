using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToCounterWhenDestroyed : MonoBehaviour
{
    public GameObject ParentTarget;
    public void AddToCounter() 
    {
        Debug.Log("ADDED TO COUNTER!");
        TargetSpawns.NumberOfTargetsDestroyed++;
        Destroy(ParentTarget);
    }
}
