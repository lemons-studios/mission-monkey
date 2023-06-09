using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public Rigidbody[] BarsRigidBody;
    public GameObject ExplosionParticles;

    public GameObject[] PrisonBars;
    public Material TransitionMaterial;
    public AudioSource barsEffectSource;
    public float maxRange = 100f;
    public float minRange = 80f;

    public void ExplodeBars()
    {
        //if (EventTriggered) return;
        //EventTriggered = true;

        ExplosionParticles.SetActive(true);
        // ExplosionParticles.GetComponent<ParticleSystem>().Play();
        for (int i = 0; i < BarsRigidBody.Length; i++)
        {
            BarsRigidBody[i].useGravity = true;
            BarsRigidBody[i].AddForce(Vector3.forward * Random.Range(minRange, maxRange));
        }
        barsEffectSource.Play();
        // StartCoroutine(WaitBeforeDestroy());
        // fadeOut();
        Destroy(gameObject);
    }

    private void Awake()
    {
        // PrisonBars = new GameObject[5];
        BarsRigidBody = new Rigidbody[5];
        for (int i = 0; i < PrisonBars.Length; i++)
        {
            BarsRigidBody[i] = PrisonBars[i].GetComponent<Rigidbody>();
        }
    }
}
