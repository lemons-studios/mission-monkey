using UnityEngine;

public class Glock : MonoBehaviour
{
    public Camera cam;
    public Transform firePoint;
    public PlayerInput.OnFootActions onFoot;
    public GameObject projectile;
    public float projectileSpeed = 100f;
    public float shotCooldown = 1f;
    public float projectileDamage = 15f;

    private Vector3 destination;
    private PlayerInput playerInput;
    private float timeToFire;

    public void ShootProjectile()
    {
        if (Time.time >= timeToFire && !PlayerDeathController.isDead)
        {
            timeToFire = Time.time + shotCooldown;

            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                destination = hit.point;
                if (hit.collider.gameObject.CompareTag("Enemy"))
                {
                    GameObject enemy = hit.collider.gameObject;
                    AiHealth hp = enemy.GetComponent<AiHealth>();
                    hp.aiDmgTaken = projectileDamage;
                    hp.aiDealtDamage = true;
                    hp.DamageEnemy();
                }
                if (hit.collider.gameObject.CompareTag("Barrel"))
                {
                    Debug.Log("barrel");
                    GameObject barrel = hit.collider.gameObject;
                    barrel.GetComponent<BarrelExplosion>().explodeBars();
                }

            }
            else
            {
                destination = ray.GetPoint(1000);
            }

            InstantiateProjectile(firePoint);
        }
    }

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Enable();
        onFoot.GunFire.performed += ctx => ShootProjectile();
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
        Destroy(projectileObj, 3);
    }
}
