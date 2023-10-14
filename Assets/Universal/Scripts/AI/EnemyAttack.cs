using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : State
{
    EnemyEyeSight eyeSight;
    public NavMeshAgent navMeshAgent;
    public PlayerMotor player;
    public int DamageToPlayer;
    public PlayerHealth playerHealth;
    private Ray AttackRay;
    public GameObject FirePoint;

    private void Awake()
    {
        eyeSight = GetComponentInParent<EnemyEyeSight>();
        player = FindAnyObjectByType<PlayerMotor>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }
    public override State RunCurrentState()
    {

        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.stoppingDistance = 5;

        Attack();

        return this;
    }

    void Attack()
    {
        AttackRay = new Ray(FirePoint.transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(AttackRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                var PlayerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();
                PlayerHealth.DamagePlayer(DamageToPlayer + (Mathf.RoundToInt(DamageToPlayer * Random.Range(0.5f, 2.0f))));
            }
        }
    }
}
