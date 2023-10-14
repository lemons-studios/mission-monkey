using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public PlayerMotor player;
    public float rotationSpeed = 3f;
    public float rotationSpeedOrigin = 10f;
    EnemyEyeSight enemyEyeSight;
    public Transform enemy;
    public Quaternion targetRotation;
    public bool correctRot = false;


    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerMotor>();
        enemyEyeSight = GetComponent<EnemyEyeSight>();
        targetRotation = Quaternion.Euler(0, 0, 0);
        enemy = GetComponentInParent<EnemyController>().transform;

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyEyeSight.seePlayer == true)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
            correctRot = false;
        }
        else
        {
            if (!correctRot)
            {
                if (transform.rotation != targetRotation)
                {
                    Quaternion startRotation = transform.rotation; // Current rotation of the object
                    Quaternion endRotation = enemy.rotation; // Target rotation

                    // Interpolate between the current rotation and the target rotation using Lerp
                    Quaternion newRotation = Quaternion.Lerp(startRotation, endRotation, rotationSpeedOrigin * Time.deltaTime);

                    // Assign the new rotation to the object
                    transform.rotation = newRotation;
                   
                   
                }
                else
                {
                    correctRot = true;
                }
            }
        }

    }
}
