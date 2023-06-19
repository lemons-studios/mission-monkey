using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGenerators : MonoBehaviour
{
    public GameObject[] FuelRods;
    public static bool AreGeneratorsOn = false;
    private float AreGeneratorsOnEventChecker = 0f;

    // Update is called once per frame
    void Update()
    {
        if (AreGeneratorsOn == true & AreGeneratorsOnEventChecker <= 0)
        {
            EnableGenerators();
        }
    }

    public void EnableGenerators()
    {
        for (int i = 0; i < FuelRods.Length; i++)
        {
            FuelRods[i].SetActive(true);
        }
    }
}
