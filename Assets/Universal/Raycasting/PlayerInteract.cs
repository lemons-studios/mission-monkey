using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float interactDistance = 3f;
    [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDistance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, interactDistance,mask)) {
            if(hitInfo.collider.GetComponent<interactable>() != null) {
                Debug.Log(hitInfo.collider.GetComponent<interactable>().promptMessage);
            }
        }
    }
}
