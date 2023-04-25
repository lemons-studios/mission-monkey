using UnityEngine;

public class PathfindingEssential : MonoBehaviour
{
    public GameObject MonkeyPlayer;
    public Transform Parent;
    public Ray hitRay;
    void Start() {
        Parent = transform.parent;
    }
    void Update() {
        
    }
}
