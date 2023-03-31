using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    // Logic states
    bool on;
    public bool startOn;

    // Visual management
    public Color onColor;
    public Color offColor;
    Renderer rend;

    // State management
    public GameObject objectToToggle;

    // Start is called before the first frame update
    void Start()
    {
        on = true;
        rend = GetComponent<Renderer>();
        rend.material.color = onColor;

        if(startOn)
        {
            objectToToggle.SetActive(true);
        }
        else
        {
            objectToToggle.SetActive(false);
        }
    }

    public void ToggleObjectState()
    {
        on = !on;

        if(on)
        {
            rend.material.color = onColor;
        }
        else
        {
            rend.material.color = offColor;
        }

        if(objectToToggle.activeSelf)
        {
            objectToToggle.SetActive(false);
        }
        else
        {
            objectToToggle.SetActive(true);
        }
    }

}
