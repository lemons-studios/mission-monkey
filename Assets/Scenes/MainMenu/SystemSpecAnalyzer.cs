using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class SystemSpecAnalyzer : MonoBehaviour
{
    private bool IsDX12Supported()
    {
        string graphicsDeviceVersion = SystemInfo.graphicsDeviceVersion;

        if(graphicsDeviceVersion.Contains("Direct3D 12"))
        {
            return true;
        }
        else return false;
    }

    private void Start()
    {
        if(!IsDX12Supported())
        {
            UnityEngine.Application.Quit();
        }
    }
}