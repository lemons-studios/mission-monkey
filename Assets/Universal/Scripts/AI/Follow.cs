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
    public Transform FirePoint;
    public GameObject BulletProjectile;
    public bool isAttacking = false;
    float rotationSpeed = 10f;
    public float BulletSpeed;
    public bool rotate;
    public int DamageToPlayer = 1;

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
                InstatiateEnemyProjectile(FirePoint);
                var PlayerHealth = hit.collider.gameObject.GetComponent<PlayerHealth>();
                PlayerHealth.DamagePlayer(DamageToPlayer + (Mathf.RoundToInt(DamageToPlayer * Random.Range(0.5f, 2.0f))));
            }
        }
    }

    public void InstatiateEnemyProjectile(Transform point)
    {
        var CurrentProjectile = Instantiate(BulletProjectile, point.position, FirePoint.transform.rotation) as GameObject;

        CurrentProjectile.SetActive(true);
        CurrentProjectile.GetComponent<Rigidbody>().velocity = point.transform.forward * BulletSpeed;
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
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
