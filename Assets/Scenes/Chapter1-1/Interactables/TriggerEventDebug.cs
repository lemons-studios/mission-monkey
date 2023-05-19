using UnityEngine;
using System.Collections;
public class TriggerEventDebug : Interactable
{
    private bool EventTriggered = false;
    public float minRange = 80f;
    public float maxRange = 100f;

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
            BarsRigidBody[i].AddForce(Vector3.forward * Random.Range(minRange, maxRange));
        }
        DisplayDistroyTransition = true;
        Debug.Log("Event triggered!");

        // StartCoroutine(WaitBeforeDestroy());
        // fadeOut();


    }
    
/*  IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(DestroyTransitionTime);
    }

    private void fadeOut()
    {
        foreach (GameObject i in PrisonBars)
        {
            Destroy(i);
        }
    } */
}