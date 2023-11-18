using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{  // Adjust this sensitivity to control the rotation speed
    public float rotationSpeed = 2.0f;
  
    public bool validTouch;
    // Set the maximum and minimum angles for rotation on the x-axis
    public float minXAngle = -90f;
    public float maxXAngle = 90f;

    private Vector2 touchStartPos;
    private float rotationX = 0f;
    public int ignoreTouch = 0;
    private void Awake()
    {
        
    }
    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(Input.touchCount -  1);

            // Check for the start of the touch
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;

            }
            // Check for the end of the touch
            else if (touch.phase == TouchPhase.Moved)
            {

                if ( Input.touchCount > ignoreTouch)
                {
                    // Calculate the touch delta position
                    Vector2 deltaPos = touch.position - touchStartPos;

                    // Rotate the camera based on touch delta
                    rotationX -= deltaPos.y * rotationSpeed * Time.deltaTime;
                    rotationX = Mathf.Clamp(rotationX, minXAngle, maxXAngle);

                    float rotationY = deltaPos.x * rotationSpeed * Time.deltaTime;

                    // Apply the rotation to the camera
                    transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y + rotationY, 0);

                    // Save the current touch position for the next frame
                    touchStartPos = touch.position;
                }
               
            }
        }
    }
}
