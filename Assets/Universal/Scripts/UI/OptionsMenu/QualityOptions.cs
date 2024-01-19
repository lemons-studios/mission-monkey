using UnityEngine;
using UnityEngine.Rendering.Universal;

public class QualityOptions : MonoBehaviour
{
    private Camera playerCamera;
    private UniversalAdditionalCameraData urpCameraData;

    private void Start() 
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        urpCameraData = playerCamera.GetComponent<UniversalAdditionalCameraData>();    
    }


    public void SetPremadeQualityProfile(int QualityProfile)
    {
        QualitySettings.SetQualityLevel(QualityProfile);
        PlayerPrefs.SetInt("Quality", QualityProfile);
    }

    public void SetAntiAliasingType(int antiAliasingLevel)
    {
        switch(antiAliasingLevel)
        {
            case 0:     // No Anti Aliasing
                urpCameraData.antialiasing = AntialiasingMode.None;
                break;
            case 2:     // FXAA
                urpCameraData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 3:     // SMAA
                urpCameraData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                break;
            case 4:     // TAA
                urpCameraData.antialiasing = AntialiasingMode.TemporalAntiAliasing;
                break;
        }

        PlayerPrefs.SetInt("AntiAliasingType", antiAliasingLevel);
    }

    public void SetAntiAliasingQuality(int antiAliasingQualityLevel)
    {
        if(PlayerPrefs.GetInt("AntiAliasingType") == 0) return;
        

        switch(antiAliasingQualityLevel)
        {
            case 1:
                urpCameraData.antialiasingQuality = AntialiasingQuality.Low;
                break;
            case 2:
                urpCameraData.antialiasingQuality = AntialiasingQuality.Medium;
                break;
            case 3:
                urpCameraData.antialiasingQuality = AntialiasingQuality.High;
                break;
        }
    }
}
