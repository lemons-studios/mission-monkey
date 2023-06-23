using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.NVIDIA;
public class SettingsMenu : MonoBehaviour
{
    public bool IsOnDX12;
    public Toggle DXRToggle;
    public Camera mainCamera;
    public AudioMixer audiomixer;
    public Slider msSlider;
    public GameObject optionMenu;
    public TMP_Dropdown qualitySelect, AASelect, RendererSelect;
    public Slider volSlider;
    float mouseSens, volume;
    public static float publicFOV, publicMouseSens, publicVolume;
    int quality, antiAliasingQuality;

    /*    public void FOV(float fov)
        {
            // GameObject.Find("OptionsMenu").GetComponent<CameraFOV>().setCameraFOV(fov);
            PlayerPrefs.SetFloat("CameraFOV", fov);
            optionMenu.GetComponent<CameraFOV>().setCameraFOV(fov);
            if (fovSlider.value != fov)
            {
                fovSlider.value = fov;
            }
        }*/

    public void MouseSens(float sens)
    {
        // GameObject.Find("OptionsMenu").GetComponent<PlayerLook>().setMouseSensitivity(sens);
        PlayerPrefs.SetFloat("MouseSens", sens);
        optionMenu.GetComponent<PlayerLook>().setMouseSensitivity(sens);
        if (msSlider.value != sens)
        {
            msSlider.value = sens;
        }
    }
    public void Quality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
        PlayerPrefs.SetInt("Quality", index);
        if (qualitySelect.value != index)
        {
            qualitySelect.value = index;
        }
    }
    public void SetAntiAliasing(int aaIndex)
    {
        // For 0.2.2
    }
    public void SetRenderer(int RendererIndex)
    {
        if (RendererIndex == 0)
        {
            Debug.Log("Set to DX11");
            UnityEditor.PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { UnityEngine.Rendering.GraphicsDeviceType.Direct3D11 });
        }
        else if (RendererIndex == 1)
        {
            Debug.Log("Set to DX12");
            UnityEditor.PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { UnityEngine.Rendering.GraphicsDeviceType.Direct3D12 });
        }
    }

    public void EnableRaytracing(bool isEnabled)
    {
        var hDRenderPipelineAsset = GraphicsSettings.currentRenderPipeline as HDRenderPipelineAsset;
        //Debug.Log(isEnabled);

        if (hDRenderPipelineAsset != null)
        {
            RenderPipelineSettings RayTracingSettings = hDRenderPipelineAsset.currentPlatformRenderPipelineSettings;
            RayTracingSettings.supportRayTracing = isEnabled;
            hDRenderPipelineAsset.currentPlatformRenderPipelineSettings = RayTracingSettings;
        }
    }
    public void EnableDLSS()
    {
        
    }
    public void Volume(float volume)
    {
        audiomixer.SetFloat("Volume", volume * volume * volume / 6400);
        // audiomixer.SetFloat("Volume", volume * volume * volume * volume / -512000);
        PlayerPrefs.SetFloat("Volume", volume);
        if (volSlider.value != volume)
        {
            volSlider.value = volume;
        }
    }
    public bool IsGraphicsCardDLSSCompatible()
    {
        string GpuName = SystemInfo.graphicsDeviceName;
        return GpuName.Contains("NVIDIA") && GpuName.Contains("RTX");
    }
    void Start()
    {
        // fov = PlayerPrefs.GetFloat("CameraFOV", 60);
        mouseSens = PlayerPrefs.GetFloat("MouseSens", 80);
        quality = PlayerPrefs.GetInt("Quality", 4);
        volume = PlayerPrefs.GetFloat("Volume", -5);


        // FOV(fov);
        MouseSens(mouseSens);
        Quality(quality);
        Volume(volume);

        Debug.Log("This computer has a NVIDIA Graphics card: " + IsGraphicsCardDLSSCompatible());

        string RendererInfo = SystemInfo.graphicsDeviceVersion;

        if (RendererInfo.Contains("Direct3D 12"))
        {
            Debug.Log("DirectX12 is Supported (Hooray!)");
        }
        else
        {
            Debug.Log("DirectX12 Is Not Supported");
        }
    }
}