using UnityEngine;

public class AddToCounterWhenDestroyed : MonoBehaviour
{
    public GameObject ParentTarget;
    public void AddToCounter()
    {
        //Debug.Log("added +1 to the counter!");
        TargetSpawns.NumberOfTargetsDestroyed++;
        Destroy(ParentTarget);
    }
}
