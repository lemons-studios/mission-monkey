using System.Collections;
using UnityEngine;

public class BarrelExplosion : WeaponInteract
{
    private int TargetDestroyCounter = 0;
    
    public GameObject Barrel;
    public Rigidbody[] PrisonBars;
    public BoxCollider[] PrisonBarColliders;
    public Rigidbody ShootingRageRigidBody;
    public BoxCollider ShootingRangeCollider;

    public int MinExplodeRange, MaxExplodeRange;
    public float TimeUntilColliderDisable;
    public void DestroyCounter()
    {
        TargetDestroyCounter++;
        if (TargetDestroyCounter == 3)
        {
            Barrel.transform.position = new Vector3(-91.856f, -0.128f, -12.164f);
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
        Barrel.transform.position = Vector3.zero;
    }

    private IEnumerator DisableRigidbodyCollision()
    {
        yield return new WaitForSeconds(TimeUntilColliderDisable);

        foreach(Rigidbody PrisonBar in PrisonBars)
        {
            PrisonBar.useGravity = false;
        }
        foreach(BoxCollider PrisonColliders in PrisonBarColliders) 
        {
            PrisonColliders.enabled = false;
        }
    }
}