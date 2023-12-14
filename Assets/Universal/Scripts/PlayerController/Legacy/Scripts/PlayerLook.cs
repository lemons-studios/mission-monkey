using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public static float xSens = 100f;
    public static float ySens = 100f;
    public Camera cam;
    public float xRotation = 0f;
    public static float averagedSens;
    
    public void ProcessLook(Vector2 input)
    {
    }

    public void setMouseSensitivity(float sensitivity)
    {
        xSens = sensitivity;
        ySens = sensitivity;
    }

    public void Update()
    {
        averagedSens = (xSens + ySens) / 2;
    }
}