using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public float xRotation = 0f;

    public static float xSens = 30f;
    public static float ySens = 30f;

    public static float[] sens = {xSens, ySens};
    // Start is called before the first frame update
    public void ProcessLook(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySens;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSens);
    }

    public void setMouseSensitivity(float sensitivity) {
        xSens = sensitivity;
        ySens = sensitivity;
    }
}
