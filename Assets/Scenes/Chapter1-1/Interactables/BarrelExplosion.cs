using UnityEngine;

public class BarrelExplosion : WeaponInteract
{


    /*public GameObject ExplosionParticles ,ShootingRangeObject;*/
    public Rigidbody[] PrisonBarsRigidbody;
    // public Rigidbody ShootingRangeObjectRigidbody;
    // private BoxCollider ShootingRangeObjectBoxCollider;
    public Material TransitionMaterial;
    public AudioSource barsEffectSource;
    public float ExplosionForce, MinExplodeRange, MaxExplodeRange;

    public override void TriggerInteract()
    {
        base.TriggerInteract();
        //ExplosionParticles.SetActive(true);
        gameObject.SetActive(false);
        // barsEffectSource.Play();

        foreach (Rigidbody PrisonRigidBody in PrisonBarsRigidbody)
        {
            PrisonRigidBody.AddForce(Vector3.forward * Random.Range(MinExplodeRange, MaxExplodeRange));
        }

        Destroy(gameObject);
    }
}
