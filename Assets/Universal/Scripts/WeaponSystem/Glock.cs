using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Glock : MonoBehaviour
{
    public Camera cam;
    public Transform firePoint;
    public PlayerInput.OnFootActions onFoot;
    public GameObject projectile;
    public float projectileSpeed = 30f;

    private Vector3 destination;
    private PlayerInput playerInput;

    public void ShootProjectile() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            destination = hit.point;
        } else {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjectile(firePoint);
    }

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.Enable();
        onFoot.GunFire.performed += ctx => ShootProjectile();
    }

    void InstantiateProjectile(Transform point) {
        var projectileObj = Instantiate(projectile, point.position, Quaternion.FromToRotation(point.position, destination)) as GameObject;
        projectileObj.SetActive(true);
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - point.position).normalized * projectileSpeed;
        Destroy (projectileObj, 3);
    }
}
