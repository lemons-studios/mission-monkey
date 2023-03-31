using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit to https://sharpcoderblog.com/blog/target-indicator-in-unity-3d for script!



public class TargetIndicator : MonoBehaviour
{
    public bool allowMultipleTargets = false;
    public Texture topLeftBorder;
    public Texture bottomLeftBorder;
    public Texture topRightBorder;
    public Texture bottomRightBorder;

    List<Collider> targets = new List<Collider>();
    Camera targetCamera;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonUp(0))
        {
            Collider selectedCollider = GetTargetFromMouseHover();

            if (selectedCollider && selectedCollider.tag == "Shootable")
            {
                /*
                if (targets.Contains(selectedCollider))
                {
                    targets.Remove(selectedCollider);
                    return;
                }
                */
                targets.Add(selectedCollider);
            }
            else
            {
                if (!allowMultipleTargets)
                {
                     targets.Clear();
                }
            }
        }
    }

    Collider GetTargetFromMouseHover()
    {
        /*
        RaycastHit hitInfo = new RaycastHit();
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out hitInfo);
        if (hit)
        {
            return hitInfo.collider;
        }

        return null;
        */



        // Create a vector at the center of our camera's viewport
        Vector3 rayOrigin = targetCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // Declare a raycast hit to store information about what our raycast has hit
        RaycastHit hit;

        // Check if our raycast has hit anything
        if (Physics.Raycast(rayOrigin, targetCamera.transform.forward, out hit, 500))
        {
            return hit.collider;
        }

        return null;
    }

    void OnGUI()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i])
            {
                Vector3 boundPoint1 = targets[i].bounds.min;
                Vector3 boundPoint2 = targets[i].bounds.max;
                Vector3 boundPoint3 = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint2.z);
                Vector3 boundPoint4 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint1.z);
                Vector3 boundPoint5 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint1.z);
                Vector3 boundPoint6 = new Vector3(boundPoint1.x, boundPoint2.y, boundPoint2.z);
                Vector3 boundPoint7 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint2.z);
                Vector3 boundPoint8 = new Vector3(boundPoint2.x, boundPoint2.y, boundPoint1.z);

                Vector2[] screenPoints = new Vector2[8];
                screenPoints[0] = targetCamera.WorldToScreenPoint(boundPoint1);
                screenPoints[1] = targetCamera.WorldToScreenPoint(boundPoint2);
                screenPoints[2] = targetCamera.WorldToScreenPoint(boundPoint3);
                screenPoints[3] = targetCamera.WorldToScreenPoint(boundPoint4);
                screenPoints[4] = targetCamera.WorldToScreenPoint(boundPoint5);
                screenPoints[5] = targetCamera.WorldToScreenPoint(boundPoint6);
                screenPoints[6] = targetCamera.WorldToScreenPoint(boundPoint7);
                screenPoints[7] = targetCamera.WorldToScreenPoint(boundPoint8);

                Vector2 topLeftPosition = Vector2.zero;
                Vector2 topRightPosition = Vector2.zero;
                Vector2 bottomLeftPosition = Vector2.zero;
                Vector2 bottomRightPosition = Vector2.zero;

                for (int a = 0; a < screenPoints.Length; a++)
                {
                    //Top Left
                    if (topLeftPosition.x == 0 || topLeftPosition.x > screenPoints[a].x)
                    {
                        topLeftPosition.x = screenPoints[a].x;
                    }
                    if (topLeftPosition.y == 0 || topLeftPosition.y > Screen.height - screenPoints[a].y)
                    {
                        topLeftPosition.y = Screen.height - screenPoints[a].y;
                    }
                    //Top Right
                    if (topRightPosition.x == 0 || topRightPosition.x < screenPoints[a].x)
                    {
                        topRightPosition.x = screenPoints[a].x;
                    }
                    if (topRightPosition.y == 0 || topRightPosition.y > Screen.height - screenPoints[a].y)
                    {
                        topRightPosition.y = Screen.height - screenPoints[a].y;
                    }
                    //Bottom Left
                    if (bottomLeftPosition.x == 0 || bottomLeftPosition.x > screenPoints[a].x)
                    {
                        bottomLeftPosition.x = screenPoints[a].x;
                    }
                    if (bottomLeftPosition.y == 0 || bottomLeftPosition.y < Screen.height - screenPoints[a].y)
                    {
                        bottomLeftPosition.y = Screen.height - screenPoints[a].y;
                    }
                    //Bottom Right
                    if (bottomRightPosition.x == 0 || bottomRightPosition.x < screenPoints[a].x)
                    {
                        bottomRightPosition.x = screenPoints[a].x;
                    }
                    if (bottomRightPosition.y == 0 || bottomRightPosition.y < Screen.height - screenPoints[a].y)
                    {
                        bottomRightPosition.y = Screen.height - screenPoints[a].y;
                    }
                }

                GUI.DrawTexture(new Rect(topLeftPosition.x - 16, topLeftPosition.y - 16, 16, 16), topLeftBorder);
                GUI.DrawTexture(new Rect(topRightPosition.x, topRightPosition.y - 16, 16, 16), topRightBorder);
                GUI.DrawTexture(new Rect(bottomLeftPosition.x - 16, bottomLeftPosition.y, 16, 16), bottomLeftBorder);
                GUI.DrawTexture(new Rect(bottomRightPosition.x, bottomRightPosition.y, 16, 16), bottomRightBorder);
            }
        }
    }
}