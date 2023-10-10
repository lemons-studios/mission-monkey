using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : State
{
    EnemyEyeSight eyeSight;
    public NavMeshAgent navMeshAgent;
    public PlayerMotor player;
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
                PlayerHealth.DamagePlayer(25); // 25 can be changed to whatever int you would like, it is just used as a default thing in this example 
                                               //shoot stuff
            }
        }
    }
}
