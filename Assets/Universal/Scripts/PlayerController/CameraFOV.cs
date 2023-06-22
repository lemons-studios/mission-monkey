using UnityEngine;

public class CameraFOV : MonoBehaviour
{
    public static float[] camfov = { fov };
    public static float fov = 60f;
    public Camera cam;
    public void setCameraFOV(float value)
    {
        fov = value;
    }
    // Update is called once per frame
    void Update()
    {
        if (cam)
        {
            cam.fieldOfView = fov;
        }
    }
}