using UnityEngine;

public class TriggerEventDebug : Interactable
{
    private bool EventTriggered = false;

    public GameObject[] PrisonBars;
    public Rigidbody[] BarsRigidBody;
    public float ExplosionForce = 20f;
    private float DestroyTransitionTime = 2.5f;

    private void Awake()
    {
        // PrisonBars = new GameObject[5];
        BarsRigidBody = new Rigidbody[5];
        for (int i = 0; i < PrisonBars.Length; i++)
        {
            BarsRigidBody[i] = PrisonBars[i].GetComponent<Rigidbody>();
        }
        Debug.Log(BarsRigidBody);
    }

    protected override void Interact()
    {
        if (EventTriggered) return;
        EventTriggered = true;
        for (int i = 0; i < BarsRigidBody.Length; i++)
        {
            BarsRigidBody[i].useGravity = true;
            BarsRigidBody[i].AddForce(Vector3.back * ExplosionForce);
            Destroy(PrisonBars[i], DestroyTransitionTime);
        }
        Debug.Log("Event triggered!");
    }
    
}