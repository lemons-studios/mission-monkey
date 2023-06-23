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
    public TMP_Dropdown qualitySelect, AASelect, RendererSelect, DLSSDropdown;
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
        // for Later
    }
    public void SetRenderer(int RendererIndex)
    {
        if (RendererIndex == 0)
        {
            Debug.Log("Set to DX11");
            #if UNITY_EDITOR
                UnityEditor.PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { UnityEngine.Rendering.GraphicsDeviceType.Direct3D11 });
            #endif
            UnityEngine.Rendering.GraphicsDeviceType targetAPI = UnityEngine.Rendering.GraphicsDeviceType.Direct3D11;
            ApplyGraphicsAPI(targetAPI);
        }
        else if (RendererIndex == 1)
        {
            Debug.Log("Set to DX12");
            #if UNITY_EDITOR
                UnityEditor.PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { UnityEngine.Rendering.GraphicsDeviceType.Direct3D12 });
            #endif

            UnityEngine.Rendering.GraphicsDeviceType targetAPI = UnityEngine.Rendering.GraphicsDeviceType.Direct3D12;
            ApplyGraphicsAPI(targetAPI);
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
    public void EnableDLSS(int DLSSIndex)
    {
        if(DLSSIndex == 0)
        {
            Debug.Log("DLSS ON");
            mainCamera.allowDynamicResolution = true;
        }
        else if(DLSSIndex == 1)
        {
            Debug.Log("DLSS OFF");
            mainCamera.allowDynamicResolution = false;
        }
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
    void ApplyGraphicsAPI(UnityEngine.Rendering.GraphicsDeviceType targetAPI)
    {
        string buildpath = Application.dataPath.Replace("/Assets", "");
        string GraphicsSettingsPath = System.IO.Path.Combine(buildpath, "ProjectSettings/GraphicsSettings.asset");
        string[] RendererSettings = System.IO.File.ReadAllLines(GraphicsSettingsPath);

        for (int i = 0; i < RendererSettings.Length; i++)
        {
            if (RendererSettings[i].StartsWith(" m_API:"))
            {
                RendererSettings[i] = " m_API: " + targetAPI;
                break;
            }
        }
        System.IO.File.WriteAllLines(GraphicsSettingsPath, RendererSettings);
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

        if (!RendererInfo.Contains("Direct3D 12"))
        {
            RendererSelect.interactable = false;
            DLSSDropdown.interactable = false;
        }
        if (IsGraphicsCardDLSSCompatible() == false)
        {
            DLSSDropdown.interactable = false;
        }
        if (!SystemInfo.supportsRayTracing)
        {
            DXRToggle.interactable = false;
        }

    }
}