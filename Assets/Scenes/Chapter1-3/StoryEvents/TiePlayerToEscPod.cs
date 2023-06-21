using UnityEngine;

public class TiePlayerToEscPod : MonoBehaviour
{
    private bool InEscapePod;
    public Transform GlueLocation;
    public GameObject Player;

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("it works??!");
            InEscapePod = true;
        }
    }
    private void Start()
    {

    }

    private void LateUpdate()
    {
        if (InEscapePod == true)
        {
            Player.transform.position = GlueLocation.transform.position;
        }
    }

}
