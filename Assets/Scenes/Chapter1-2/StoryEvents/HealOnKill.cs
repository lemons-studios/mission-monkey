using UnityEngine;

public class HealOnKill : MonoBehaviour
{
    public GameObject Robot;

    private void Awake()
    {

    }
    void Update()
    {
        if(Robot.GetComponent<AiHealth>().aiHealth <= 0)
        {
            PlayerHealth.healedHealth = true;
            PlayerHealth.healthHealed = Random.Range(13,17);
            PlayerHealth.HealPlayer();
        }
    }
}
