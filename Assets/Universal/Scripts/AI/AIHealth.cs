using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public int HitPoints = 100;
    public ParticleSystem DestructionParticles;

    private void Update()
    {
        if (HitPoints <= 0)
        {
            if (DestructionParticles != null)
            {
                DestructionParticles.Play();
            }
            Destroy(gameObject);
        }
    }
}