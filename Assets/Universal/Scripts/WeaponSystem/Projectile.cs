using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool collided;
    private void OnCollisionEnter(Collision co) {
        if (!collided) {
            collided = true;
            Destroy(gameObject);
        }
    }
}
