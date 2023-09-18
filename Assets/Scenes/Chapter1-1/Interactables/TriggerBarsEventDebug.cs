using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class TriggerBarsEventDebug : Interactable
{
    public float minRange = 80f;
    public float maxRange = 100f;
    public AudioSource barsEffectSource;

    public GameObject[] PrisonBars;
    public Rigidbody[] BarsRigidBody;
    public Material TransitionMaterial;
    // private float DestroyTransitionTime = 2.5f;

    private void Awake()
    {
        // PrisonBars = new GameObject[5];
        BarsRigidBody = new Rigidbody[5];
        for (int i = 0; i < PrisonBars.Length; i++)
        {
            BarsRigidBody[i] = PrisonBars[i].GetComponent<Rigidbody>();
        }
    }

    protected override void Interact()
    {
        /* for (int i = 0; i < BarsRigidBody.Length; i++)
        {
            BarsRigidBody[i].useGravity = true;
            BarsRigidBody[i].AddForce(Vector3.forward * Random.Range(minRange, maxRange));
        } 
        */
        foreach(Rigidbody rb in BarsRigidBody)
        {
            rb.useGravity = true;
            rb.AddForce(Vector3.forward * Random.Range(minRange, maxRange));
        }
        barsEffectSource.Play();

        // StartCoroutine(WaitBeforeDestroy());
        // fadeOut();
    }
}