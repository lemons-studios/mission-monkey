using UnityEngine;

public class DropHealthPack : MonoBehaviour
{
    public GameObject Robot, HealthPack;

    private void Awake()
    {

    }
    void Update()
    {
        if(Robot.GetComponent<AiHealth>().aiHealth <= 0 & PlayerHealth.Health <= 60)
        {
            PlayerHealth.healedHealth = true;
            PlayerHealth.healthHealed = Random.Range(13,17);
        }
    }
}
