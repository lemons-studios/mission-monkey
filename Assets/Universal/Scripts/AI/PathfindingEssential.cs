using UnityEngine;
using UnityEngine.AI;

public class PathfindingEssential : MonoBehaviour
{
    public Transform Parent;
    
    void Start() {
        Parent = transform.parent;
    }
}
