using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float holdTimeThreshold = 1.0f; // Set the time threshold for holding the button
   
    private bool isHolding = false;
    public CameraMove cameraMove;

    void Awake()
    {
        cameraMove = FindFirstObjectByType<CameraMove>();
    }
    void Start()
    {

    }

    void Update()
    {
        // Check if the button is being held
        //

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //add Interact logic
        isHolding = true;
        cameraMove.ignoreTouch++;
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {

        isHolding = false;
        cameraMove.ignoreTouch--;
    }




}
