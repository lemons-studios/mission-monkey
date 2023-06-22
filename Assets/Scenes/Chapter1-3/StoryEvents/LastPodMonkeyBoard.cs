using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastPodMonkeyBoard : MonoBehaviour
{
    public GameObject Monkey, MonkeyInPod;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monkey"))
        {
            Monkey.SetActive(false);
            MonkeyInPod.SetActive(true);
        }
    }
}