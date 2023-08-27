using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float CameraRotationSpeed = 2f;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * CameraRotationSpeed * Time.deltaTime);
    }
}
