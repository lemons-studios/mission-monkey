using UnityEngine;

public class SpawnTargets : MonoBehaviour
{
    public GameObject[] Targets;
    public void EnableTargets()
    {
        Debug.Log("Weapon Picked Up!");
        foreach(GameObject Target in Targets)
        {
            Target.SetActive(true);
        }
    }
}