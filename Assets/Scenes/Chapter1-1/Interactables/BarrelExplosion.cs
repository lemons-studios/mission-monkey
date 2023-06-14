using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
    public GameObject Barrel;
    public BoxCollider[] PrisonBarColliders;
    public BoxCollider[] ShootingRangeColliders;
    public Rigidbody[] BarsRigidBody;
    public Rigidbody[] ShootingRangeRigidBody;
    public GameObject ExplosionParticles;
    public GameObject[] PrisonBars;
    public GameObject[] ShootingRangeBars;
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
        Barrel.SetActive(false);
        for (int i = 0; i < BarsRigidBody.Length; i++)
        {
            BarsRigidBody[i].useGravity = true;
            BarsRigidBody[i].AddForce(Vector3.forward * Random.Range(minRange, maxRange));
            //PrisonBarColliders[i].size = new Vector3(0.1f,0.1f,0.1f);

        }
        for (int i = 0; i < ShootingRangeRigidBody.Length; i++)
        {
            ShootingRangeRigidBody[i].useGravity = true;
            ShootingRangeRigidBody[i].AddForce(Vector3.right * Random.Range(100, 150));
            //ShootingRangeColliders[i].size = new Vector3(0.1f,0.1f,0.1f);

        }
        barsEffectSource.Play();
        Destroy(gameObject);


    }

    private void Awake()
    {
        BarsRigidBody = new Rigidbody[5];
        PrisonBarColliders = new BoxCollider[5];
        ShootingRangeColliders = new BoxCollider[5];

        for (int i = 0; i < PrisonBars.Length; i++)
        {
            BarsRigidBody[i] = PrisonBars[i].GetComponent<Rigidbody>();
            PrisonBarColliders[i] = PrisonBars[i].GetComponent<BoxCollider>();
        }
        ShootingRangeRigidBody = new Rigidbody[5];
        for (int i = 0; i < ShootingRangeBars.Length; i++)
        {
            ShootingRangeRigidBody[i] = ShootingRangeBars[i].GetComponent<Rigidbody>();
            ShootingRangeColliders[i] = ShootingRangeBars[i].GetComponent<BoxCollider>();
        }
    }
}
