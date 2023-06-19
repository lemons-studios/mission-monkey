using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerFocus : Interactable
{
    public GameObject monitor;
    public Camera PlayerCam;
    public Vector3 MonitorCameraOffset;

    protected override void Interact()
    {
        transform.position = monitor.transform.position + MonitorCameraOffset;
    }
}
