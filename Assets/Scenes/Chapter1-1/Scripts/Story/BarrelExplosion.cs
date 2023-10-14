using System.Collections;
using UnityEngine;

public class BarrelExplosion : WeaponInteract
{
    private int TargetDestroyCounter = 0;

    public Rigidbody[] PrisonBars;
    public BoxCollider[] PrisonBarColliders;
    public Rigidbody ShootingRageRigidBody;
    public BoxCollider ShootingRangeCollider;
    public GameObject Barrel;

    public AudioSource ExplosionSoundEffect;
    public ParticleSystem ExplosionParticles;

    public int MinExplodeRange, MaxExplodeRange;
    public float TimeUntilColliderDisable;
    public void DestroyCounter()
    {
        TargetDestroyCounter++;
        if (TargetDestroyCounter == 3)
        {
            gameObject.transform.position = new Vector3(-91.856f, -0.128f, -12.164f);
        }
    }
    public override void TriggerInteract()
    {
        base.TriggerInteract();
        foreach (Rigidbody PrisonBar in PrisonBars)
        {
            PrisonBar.AddForce(Vector3.forward * Random.Range(MinExplodeRange, MaxExplodeRange));
        }
        StartCoroutine(DisableRigidbodyCollision());
        StartCoroutine(DisableParticles());
        Barrel.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        ExplosionSoundEffect.Play();
        ExplosionParticles.Play();
        
    }

    private IEnumerator DisableParticles()
    {
        yield return new WaitForSeconds(1.25f);
        ExplosionParticles.Stop();
    }

    private IEnumerator DisableRigidbodyCollision()
    {
        yield return new WaitForSeconds(TimeUntilColliderDisable);
        ExplosionParticles.Stop();
        foreach (Rigidbody PrisonBar in PrisonBars)
        {
            PrisonBar.useGravity = false;
        }
        foreach (BoxCollider PrisonColliders in PrisonBarColliders)
        {
            PrisonColliders.enabled = false;
        }
    }
}