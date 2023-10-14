using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Projectile;
    public GameObject Player;
    private Ray TurretRay;
    public float RotationSpeed = 1.5f;
    public float BulletSpeed = 12.5f;
    public bool IsAIDisabled = false;

    private void Update()
    {
        if (!IsAIDisabled)
        {
            TurretRay = new Ray(FirePoint.transform.position, transform.forward);
            RaycastHit Hit;

            Vector3 PlayerPosition = Player.transform.position - transform.position;
            float SingleStep = RotationSpeed * Time.deltaTime;
            Vector3 RotationDirection = Vector3.RotateTowards(transform.forward, PlayerPosition, SingleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(RotationDirection);

            if (Physics.Raycast(TurretRay, out Hit))
            {
                if (Hit.collider.gameObject.CompareTag("Player"))
                {
                    InstatiateTurretProjectile(FirePoint);
                    var PlayerHealth = Hit.collider.gameObject.GetComponent<PlayerHealth>();
                    PlayerHealth.DamagePlayer(1);
                }
            }
        }

        if (IsAIDisabled)
        {
            gameObject.transform.rotation = default;
            return;
        }
    }

    public void InstatiateTurretProjectile(Transform point)
    {
        var CurrentProjectile = Instantiate(Projectile, point.position, FirePoint.transform.rotation) as GameObject;

        CurrentProjectile.SetActive(true);
        CurrentProjectile.GetComponent<Rigidbody>().velocity = point.transform.forward * BulletSpeed;
    }
}