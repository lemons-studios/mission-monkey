using UnityEngine;

public class PickupHealth : MonoBehaviour
{
    public GameObject Player, MedKit;
    private void Update()
    {
        float distanceBetweenPlayer = Mathf.Round(Vector3.Distance(Player.transform.position, MedKit.transform.position));
        //Debug.Log("Distance between Player and medkit: " + distanceBetweenPlayer);
        if (distanceBetweenPlayer <= 1.5f)
        {
            PlayerHealth.healthHealed = Random.Range(8, 17);
            PlayerHealth.healedHealth = true;
            PlayerHealth.HealPlayer();
            Destroy(MedKit);
        }
    }
}
