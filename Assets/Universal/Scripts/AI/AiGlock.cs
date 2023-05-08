using System.Collections.Generic;
using UnityEngine;

public class AiGlock : MonoBehaviour
{
    [SerializeField]
    private GameObject ai;
    private Vector3 destination;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float projectileSpeed = 100f;
    private List<GameObject> projectiles;

    [SerializeField]
    private float shotCooldown = 1f;
    private float timeToFire;

    public void ShootProjectile()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + shotCooldown;

            Ray ray = new Ray(transform.position, ai.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
            }
            else
            {
                destination = ray.GetPoint(1000);
            }

            InstantiateProjectile(firePoint);
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
        projectiles.Add(projectileObj);
        Destroy(projectileObj, 3f);
    }
}
