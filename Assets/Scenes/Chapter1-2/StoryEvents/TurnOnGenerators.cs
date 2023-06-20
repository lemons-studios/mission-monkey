using UnityEngine;

public class TurnOnGenerators : MonoBehaviour
{
    public GameObject[] FuelRods;
    public GameObject ReactorDoor, TestingChamberDoor;
    public static bool AreGeneratorsOn = false;
    private bool ReactorDoorOpen, TestingChamberDoorOpen;
    private float AreGeneratorsOnEventChecker = 0f;

    private void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            FuelRods[i].SetActive(false);
        }
    }
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
        ReactorDoorOpen = !ReactorDoorOpen;
        TestingChamberDoorOpen = !TestingChamberDoorOpen;

        for (int i = 0; i < FuelRods.Length; i++)
        {
            FuelRods[i].SetActive(true);
        }
        ReactorDoor.GetComponent<Animator>().SetBool("DoorOpen", ReactorDoorOpen);
        TestingChamberDoor.GetComponent<Animator>().SetBool("DoorOpen", TestingChamberDoorOpen);
    }
}
