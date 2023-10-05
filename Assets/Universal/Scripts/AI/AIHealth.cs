using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public float HitPoints = 100;
    public ParticleSystem DestructionParticles;
    private void Update()
    {
        if(HitPoints <= 0)
        {
            if (DestructionParticles != null)
            {
                DestructionParticles.Play();
            }
            Destroy(gameObject);
        }
    }
}
