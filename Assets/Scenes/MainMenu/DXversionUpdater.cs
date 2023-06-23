using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DXversionUpdater : MonoBehaviour
{
    public TextMeshProUGUI DXVersionChecker;
    void Awake()
    {
        if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Direct3D12)
        {
            DXVersionChecker.text = "Alpha 0.2.1 - DirectX12";
        }
        else if(SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Direct3D11)
        {
            DXVersionChecker.text = "Alpha 0.2.1 - DirectX12";
        }
    }

}
