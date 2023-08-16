using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Glock : MonoBehaviour
{
    public GameObject FirePoint, BulletProjectile;
    private PlayerInput Input;

    void Start()
    {
       Input.OnFoot.GunFire.performed += FireGlock;
    }
    public void FireGlock(InputAction.CallbackContext context)
    {
        Debug.Log("It Works??!11");
    }
}
