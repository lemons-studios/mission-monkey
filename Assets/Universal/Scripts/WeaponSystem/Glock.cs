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

    private Vector3 destination;
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        onFoot.GunFire.performed += ctx => UnityEngine.Debug.Log("bullet");;
    }

    void InstantiateProjectile(Transform point) {
        var projectileObj = Instantiate(projectile, point.position, Quaternion.identity) as GameObject;
    }

    void ShootProjectile() {
        UnityEngine.Debug.Log("shot a bullet");
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            destination = hit.point;
        } else {
            destination = ray.GetPoint(1000);
        }

        InstantiateProjectile(firePoint);
    }

    void Start() {

    }
}
