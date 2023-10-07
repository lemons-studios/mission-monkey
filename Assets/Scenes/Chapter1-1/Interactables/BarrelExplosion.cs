using UnityEngine;

public class BarrelExplosion : WeaponInteract
{
    public Rigidbody[] PrisonBarsRigidbody;
    public Material TransitionMaterial;
    private AudioSource BarsEffectSource;
    public float ExplosionForce, MinExplodeRange, MaxExplodeRange;

    private void Start()
    {
        BarsEffectSource = GetComponent<AudioSource>();
    }

    public override void TriggerInteract()
    {
        base.TriggerInteract();
        //ExplosionParticles.SetActive(true);

        BarsEffectSource.Play();


        foreach (Rigidbody PrisonRigidBody in PrisonBarsRigidbody)
        {
            PrisonRigidBody.AddForce(Vector3.forward * Random.Range(MinExplodeRange, MaxExplodeRange));
        }

        Destroy(gameObject);
    }
}
