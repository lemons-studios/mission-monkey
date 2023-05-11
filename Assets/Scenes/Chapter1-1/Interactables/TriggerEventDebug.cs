using UnityEngine;

public class TriggerEventDebug : Interactable
{
    private bool EventTriggered = false;

    public GameObject[] PrisonBars;
    public Rigidbody[] BarsRigidBody;
    public Material TransitionMaterial;
    private float DestroyTransitionTime = 2.5f;
    private bool DisplayDistroyTransition = false;

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
            BarsRigidBody[i].AddForce(Vector3.back * Random.Range(30.0f, 99.99f));
        }
        DisplayDistroyTransition = true;
        Debug.Log("Event triggered!");
    }

    private void Update()
    {
        if (DisplayDistroyTransition)
        {
            if (TransitionMaterial.color.a >= 0.69420)
            {
                Color mat = TransitionMaterial.color;
                mat.a -= 0.2f;
                TransitionMaterial.color = mat;
            } else
            {
                Destroy(gameObject);
            }
        }
    }

}