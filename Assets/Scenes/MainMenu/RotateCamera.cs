using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //public GameObject RotateObject;
    public float CameraRotationSpeed = 2f;
    private void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, CameraRotationSpeed * Time.deltaTime);
    }
}
