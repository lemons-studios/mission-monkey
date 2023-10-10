using UnityEngine;
using UnityEngine.AI;

public class Follow : State
{
    public EnemyEyeSight eyeSight;
    public NavMeshAgent navMeshAgent;
    public PlayerMotor player;
    public PlayerHealth playerHealth;
    public Searching searching;
    public static Vector3 targetPosition;
    bool isSearching = false;
    private Ray AttackRay;
    public GameObject FirePoint;
    public bool isAttacking = false;
    float rotationSpeed = 10f;
    public bool rotate;

    private void Awake()
    {
        eyeSight = GetComponentInParent<EnemyEyeSight>();
        player = FindAnyObjectByType<PlayerMotor>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        playerHealth = FindAnyObjectByType<PlayerHealth>();
    }

    public void Search()
    {
        if (isSearching == false)
        {
            InvokeRepeating("FindPlayer", 1, 1);
        }
    }


    public override State RunCurrentState()
    {

        navMeshAgent.SetDestination(targetPosition);
        navMeshAgent.stoppingDistance = 5;


        if (eyeSight.seePlayer == false)
        {
            CancelInvoke("FindPlayer");
            CancelInvoke("Attack");
            isAttacking = false;
            isSearching = false;
            navMeshAgent.updateRotation = true;
            return searching;

        }
        else
        {


            navMeshAgent.updateRotation = false;

            if (!isAttacking)
            {
                isAttacking = true;

                InvokeRepeating(nameof(Attack), 1, 1);

            }
        }
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
                PlayerHealth.DamagePlayer(25);
             // 25 can be changed to whatever int you would like, it is just used as a default thing in this example 
                                //shoot stuff
            }
        }
    }


    void FindPlayer()
    {
        isSearching = true;
        if (eyeSight.seePlayer == true)
        {
            targetPosition = player.transform.position;
        }
        else
        {

        }
    }

    void LookAtPlayer()
    {
        Debug.Log("afejio");
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
