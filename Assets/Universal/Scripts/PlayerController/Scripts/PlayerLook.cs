using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public static float[] sens = { xSens, ySens };
    public static float xSens = 100f;
    public static float ySens = 100f;
    public Camera cam;
    public float xRotation = 0f;
    public static float averagedSens;

    // Start is called before the first frame update
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // xRotation -= (mouseY * Time.deltaTime) * ySens;
        xRotation -= (mouseY * Time.deltaTime) * ySens * ySens / 200;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        // transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSens);
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSens * xSens / 200);
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
