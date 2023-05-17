using UnityEngine;

public class ViewBobbing : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public float sineBob = 1f;
    public float BobMultiplier = 1.25f;
    public bool isMoving;
    private bool bobView = false;

    public void EnableViewBobbing()
    {
        bobView = true;
    }
    public void DisableViewBobbing()
    {
        bobView = false;
    }

    void Update()
    {
        if (bobView && !PlayerDeathController.isDead)
        {
            cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.4f + (Mathf.Abs(Mathf.Sin(Time.fixedTime * sineBob)) * BobMultiplier), player.transform.position.z);
        }
    }
}