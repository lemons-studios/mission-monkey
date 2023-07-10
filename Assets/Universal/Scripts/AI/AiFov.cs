using System;
using System.Collections;
using UnityEngine;
public class AiFoV : MonoBehaviour
{
    public GameObject Ai;
    [Range(0, 130)]
    public float angle;
    public bool canSeePlayer;
    public static bool AiSeePlayer;
    public LayerMask obstructionMask;
    public static GameObject Player;
    public float radius, AttackRadius;
    public LayerMask targetMask;
    private Vector3 targetPos;

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        RaycastHit hit;
    }
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    public void FixedUpdate()
    {
        if (canSeePlayer == true)
        {
            AiSeePlayer = true;
        }
        else
        {
            AiSeePlayer = false;
        }
    }
}