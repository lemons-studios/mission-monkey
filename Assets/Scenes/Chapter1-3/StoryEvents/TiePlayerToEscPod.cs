using UnityEngine;

public class TiePlayerToEscPod : MonoBehaviour
{
    public GameObject escPod;
    public GameObject Player;

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("it works??!");
            Player.transform.SetParent(escPod.transform, true);
        }
    }
}
