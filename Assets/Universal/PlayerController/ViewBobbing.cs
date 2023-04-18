using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBobbing : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public float sineBob = 1f;
    public float BobMultiplier = 1.25f; 
    public bool isMoving;

    void Update()
    {
         cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.6f - (Mathf.Abs(Mathf.Sin(Time.fixedTime * sineBob)) * BobMultiplier), player.transform.position.z);
    }
}