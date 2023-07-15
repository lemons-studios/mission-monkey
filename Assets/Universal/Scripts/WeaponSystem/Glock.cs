using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.PlayerInput;

public class Glock : MonoBehaviour
{
    public InputAction Fire;
    public static float GlockDamage;
    public GameObject FirePoint;
    public Animator GlockAnimator;
    private int Crit;

    private void Awake()
    {

    }

    private void Update()
    {
        Fire.performed += ctx => FireWeapon();
    }
    private void FireWeapon()
    {
        DetermineDamage();
        Debug.Log("clicked");
    }

    void DetermineDamage()
    {
        Crit = Random.Range(1, 20);
        if(Crit == 20)
        {
            GlockDamage = Random.Range(10, 17) * 2;
            Debug.Log("Crit!" + GlockDamage);
        }
        else
        {
            GlockDamage = Random.Range(10, 17);
        }
    }
}
