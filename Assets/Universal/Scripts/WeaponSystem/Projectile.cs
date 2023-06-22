using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;

    private void OnCollisionEnter(Collision co)
    {
        if (
            !collided
            && !co.collider.gameObject.CompareTag("ProjectileIgnore")
            && !co.collider.gameObject.CompareTag("Enemy")
        )
        {
            collided = true;
            Destroy(gameObject);
        }
    }
}
