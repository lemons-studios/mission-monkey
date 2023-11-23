using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;


public class CameraMove : MonoBehaviour
{  // Adjust this sensitivity to control the rotation speed

    public float rotationSpeed = 2.0f;
    public float minXAngle = -90f;
    public float maxXAngle = 90f;
    public Vector2 touchDelta = Vector2.zero;
    public RectTransform joyStickMask; // Assign this in the Inspector
    public RectTransform buttonMasks;
    public int ignoreTouch = 0;
    private float rotationX = 0f;

    private void OnEnable()
    {
        // Enable EnhancedTouch to use Unity's new Input System for touch
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        // Disable EnhancedTouch when the script is disabled
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        UnityEngine.InputSystem.EnhancedTouch.Touch? touch = null;
        foreach (var activeTouch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            touch = activeTouch;
            break;
        }

        // If there is no touch, set deltaPos to zero
        Vector2 deltaPos = touch.HasValue ? touch.Value.delta : Vector2.zero;
       

        // Convert touch position to local coordinates of the UI mask
        if (touch.HasValue)
        {
            Vector2 touchPos = touch.Value.screenPosition;
            Vector2 localTouchPos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyStickMask, touchPos, null, out localTouchPos))
            {
                // Check if the touch is inside the UI mask before skipping rotation
                if (joyStickMask.rect.Contains(localTouchPos))
                {
                    deltaPos = Vector2.zero; // Set deltaPos to zero
                    
                }
            }
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonMasks, touchPos, null, out localTouchPos))
            {
                // Check if the touch is inside the UI mask before skipping rotation
                if (buttonMasks.rect.Contains(localTouchPos))
                {
                    deltaPos = Vector2.zero; // Set deltaPos to zero

                }
            }
        }
        touchDelta = deltaPos;
        // Rotate the camera based on touch delta
        rotationX -= deltaPos.y * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, minXAngle, maxXAngle);

        float rotationY = deltaPos.x * rotationSpeed * Time.deltaTime;

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y + rotationY, 0);
       
    }
}



