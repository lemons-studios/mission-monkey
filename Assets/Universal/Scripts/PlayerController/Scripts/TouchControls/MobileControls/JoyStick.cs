using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RectTransform background;
    public RectTransform knob;
    public CameraMove cameraMove;
    private bool isJoystickActive = false;
    private Vector2 inputVector;

    private void Awake()
    {
        cameraMove = FindFirstObjectByType<CameraMove>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isJoystickActive = true;
        OnDrag(eventData);
        cameraMove.ignoreTouch++;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isJoystickActive = false;
        inputVector = Vector2.zero;
        knob.anchoredPosition = Vector2.zero;
        cameraMove.ignoreTouch--;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isJoystickActive)
        {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out pos))
            {
                pos.x = (pos.x / background.sizeDelta.x);
                pos.y = (pos.y / background.sizeDelta.y);

                inputVector = new Vector2(pos.x * 2 + 1, pos.y * 2 - 1);
                inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

                knob.anchoredPosition = new Vector3(inputVector.x * (background.sizeDelta.x / 2), inputVector.y * (background.sizeDelta.y / 2));
            }
        }
    }

    public Vector2 GetInputVector()
    {
        return inputVector;
    }
}

 
  

