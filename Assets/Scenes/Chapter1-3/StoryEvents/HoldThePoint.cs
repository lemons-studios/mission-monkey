using UnityEngine;
using TMPro;

public class HoldThePoint : MonoBehaviour
{
    public GameObject MonkeyModel;
    public TextMeshProUGUI TimerText;
    public float SecondsUntilComplete = 150f;
    public static bool AreMonkeysFree = false;
    int updateCheck = 0;

    private void Awake()
    {
        TimerText.gameObject.SetActive(false);
    }
    private void Update()
    {
        TimerText.text = SecondsUntilComplete.ToString();
        if (AreMonkeysFree == true)
        {
            TimerText.gameObject.SetActive(true);
            SelfDestructSequence();
            AreMonkeysFree = false;
        }
        else
        {
            return;
        }
    }
    public void SelfDestructSequence()
    {
        SecondsUntilComplete -= Time.deltaTime;
        if (SecondsUntilComplete == 150f || SecondsUntilComplete == 120f || SecondsUntilComplete == 90f || SecondsUntilComplete == 60f || SecondsUntilComplete == 30f)
        {
            SpawnWave();
        }
        if (SecondsUntilComplete == 0)
        {

        }
    }
    public void SpawnWave()
    {
        
    }
}