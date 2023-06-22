using System.Collections.Generic;
using UnityEngine;

public class AiGlock : MonoBehaviour
{
    [SerializeField]
    private GameObject ai;

    [SerializeField]
    private float damage;
    private Vector3 destination;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float projectileSpeed = 100f;
    private List<GameObject> projectiles;

    [SerializeField]
    private float shotCooldown = 1f;
    private float timeToFire;

    private void Update()
    {
        damage = Random.Range(3, 7);
    }
    public void ShootProjectile()
    {
        if (Time.time >= timeToFire)
        {
            //for (int i = 0; i < firePoint.Length; i++)
            //{
                timeToFire = Time.time + shotCooldown;

                // Ray ray = new Ray(transform.position, ai.transform.forward);
                Ray ray = new Ray(
                    transform.position,
                    (player.transform.position - ai.transform.position)
                );
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    destination = hit.point;
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        PlayerHealth.damageTaken = damage;
                        PlayerHealth.dealtDamage = true;
                        PlayerHealth.DamagePlayer();
                    }
                }
                else
                {
                    destination = ray.GetPoint(1000);
                }

                InstantiateProjectile(firePoint/*[i]*/);
            //}


        }
    }

    void InstantiateProjectile(Transform point)
    {

            var projectileObj =
            Instantiate(
                projectile,
                point.position,
                Quaternion.FromToRotation(point.position, destination)
            ) as GameObject;
            projectileObj.SetActive(true);
            projectileObj.GetComponent<Rigidbody>().velocity =
                (destination - point.position).normalized * projectileSpeed;
            Destroy(projectileObj, 3f);
        

    }
}
