using UnityEngine;

public class ComputerCaptcha : MonoBehaviour
{
    public static int EnemiesClearedOnWave = 0;
    public GameObject[] Wave1Enemies, Wave2Enemies, Wave3Enemies;
    public static bool isEventReady = false;
    private bool Wave1Destroyed, Wave2Destroyed, Wave3Destroyed = true;
    private int HasEventTriggered;

    void Update()
    {
        if(isEventReady == true & HasEventTriggered == 0)
        {
            Wave1();
            HasEventTriggered++;
        }
    }

    private void Wave1()
    {
        for (int i = 0; i < 4; i++)
        {
            Wave1Enemies[i].SetActive(true);
        }

    }
    private void Wave2()
    {
        for (int i = 0; i < 5; i++)
        {
            Wave2Enemies[i].SetActive(true);
        }

    }
    private void Wave3()
    {
        for (int i = 0; i < 6; i++)
        {
            Wave3Enemies[i].SetActive(true);
        }
    }
}
