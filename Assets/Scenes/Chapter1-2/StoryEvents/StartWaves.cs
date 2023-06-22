using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaves : MonoBehaviour
{
    public GameObject[] FuelRods;
    public GameObject ReactorDoor, Parent;
    private bool IsDoorOpen;
    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GeneratorEnable();
        }
    }
    public void GeneratorEnable()
    {
        IsDoorOpen = !IsDoorOpen; 
        Debug.Log("uh oh..");
        for(int i = 0; i < FuelRods.Length; i++)
        {
            ///RodsOn = !RodsOn;
            ///FuelRods[i].GetComponent<Animator>().SetBool("EventTriggered", RodsOn);
            FuelRods[i].GetComponent<Light>().intensity = 400;
        }
        //ReactorDoor.GetComponent<Animator>().SetBool("DoorOpen", IsDoorOpen);
        SpawnWave1.isEventReady = true;
        Destroy(Parent);
        
    }
}
