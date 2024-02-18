using UnityEngine;

public class EnemyAttackBase : MonoBehaviour
{
    public GameObject firePointOrigin;
    private LayerMask playerLayerMask;
    private Vector3 forward;
    public float rayLength = Mathf.Infinity;
    public float enemyAccuracy = 3;

    private void Start() 
    {
        playerLayerMask = 1 << 3;   // Bit shift to "player" layer
        forward = firePointOrigin.transform.TransformDirection(Vector3.forward);
    }

}
