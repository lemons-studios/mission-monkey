using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraFov : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        // Absolutely no idea why the camera resets itself to 60 fov each time the game starts, hopefully this script fixes that
        cam = GetComponent<Camera>();
        cam.fieldOfView = 90;
    }
}
