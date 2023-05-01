using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FovValueUpdater : MonoBehaviour
{
    public TextMeshProUGUI FovValue;
    public Camera fovValueCamera;
    void Update()
    {
        FovValue.text = fovValueCamera.fieldOfView.ToString() + "°";
    }
}
