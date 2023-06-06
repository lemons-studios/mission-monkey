using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public float minRange = 80f;
    public float maxRange = 100f;
    public AudioSource barsEffectSource;

    public GameObject[] PrisonBars;
    public Rigidbody[] BarsRigidBody;
    public Material TransitionMaterial;

    private void Awake()
    {
        // PrisonBars = new GameObject[5];
        BarsRigidBody = new Rigidbody[5];
        for (int i = 0; i < PrisonBars.Length; i++)
        {
            BarsRigidBody[i] = PrisonBars[i].GetComponent<Rigidbody>();
        }
    }
    public void explodeBars()
    {
        //if (EventTriggered) return;
        //EventTriggered = true;

        for (int i = 0; i < BarsRigidBody.Length; i++)
        {
            BarsRigidBody[i].useGravity = true;
            BarsRigidBody[i].AddForce(Vector3.forward * Random.Range(minRange, maxRange));
        }
        barsEffectSource.Play();

        // StartCoroutine(WaitBeforeDestroy());
        // fadeOut();
    }
}
