using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioClip shootSoundEffect;   
    public GameObject attackPoint;
    
    private NavMeshAgent agent;
    private EnemyNavigation enemyNavigation;
    public int damageAmount;
    public float timeBetweenAttacks, shootingDistance;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        enemyNavigation = GetComponent<EnemyNavigation>();
        StartCoroutine(EnemyAttackHandler());   // This entire AI system is built off coroutines lol
    }

    private IEnumerator EnemyAttackHandler()
    {
        while(true)
        {
            if(agent.remainingDistance <= shootingDistance && enemyNavigation.hasNoticedPlayer())
            {
                if(sfxSource != null & shootSoundEffect != null)
                {
                    sfxSource.PlayOneShot(shootSoundEffect);
                }
                DirectHitAttack();
            }
            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }

    private void DirectHitAttack()
    {
        // Fire a raycast towards the player and check if it hits, then do the damage stuff if it hits
        RaycastHit hit;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        Vector3 raycastOrigin = attackPoint.transform.position;
        Vector3 directionToTarget = (player.transform.position - raycastOrigin).normalized;

        Debug.DrawRay(raycastOrigin, directionToTarget);
        if(Physics.Raycast(raycastOrigin, directionToTarget, out hit))
        {
            if(hit.collider.GetComponent<PlayerHealth>() != null)
            {
                hit.collider.GetComponent<PlayerHealth>().DamagePlayer(damageAmount);
            }
        }
    }

    private void AreaOfEffectAttack()
    {
        // TODO: AoE Attacks
    }
}
