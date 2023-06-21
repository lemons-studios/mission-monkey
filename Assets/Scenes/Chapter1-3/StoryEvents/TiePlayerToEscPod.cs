using UnityEngine;

public class TiePlayerToEscPod : MonoBehaviour
{
    public static bool InEscapePod;
    public Transform GlueLocation;
    public GameObject Player;

    private void LateUpdate()
    {
        if (InEscapePod == true)
        {
            Player.transform.position = GlueLocation.transform.position;
        }
    }

}
