using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 10f;
    public float turnSpeed = 5f;

    bool followingPlayer;

    // Damage cooldown period
    bool canDoDamage = true;
    public float damageCooldownTimer = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if(followingPlayer)
        {
            TurnTowardsPlayer();

            // Autopilot move
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            followingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            followingPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(canDoDamage)
        {
            PlayerHealthManager playerHealth = collision.gameObject.GetComponent<PlayerHealthManager>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(1);
            }
            StartDamageCooldown();
        }
    }

    void StartDamageCooldown()
    {
        canDoDamage = false;
        Invoke("EnableDamage", damageCooldownTimer);
    }

    void EnableDamage()
    {
        canDoDamage = true;
    }

    void TurnTowardsPlayer()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = player.transform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
