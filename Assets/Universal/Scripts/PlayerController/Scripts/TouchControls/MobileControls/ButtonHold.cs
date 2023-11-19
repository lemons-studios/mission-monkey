using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
       
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(Shoot());
        isHolding = true;
        cameraMove.ignoreTouch++;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StopCoroutine(Shoot());
        isHolding = false; 
        cameraMove.ignoreTouch--;
    }

   

   

    IEnumerator Shoot()
    {
        Debug.Log("Shoot");
        yield return new WaitForSeconds(.1f);
        if(isHolding )
        {
            StartCoroutine(Shoot());
        }
    }
}
