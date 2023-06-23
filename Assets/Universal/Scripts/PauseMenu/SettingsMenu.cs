using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEditor;
public class SettingsMenu : MonoBehaviour
{
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
        if(RendererIndex == 0)
        {
            Debug.Log("Set to DX11");
            UnityEditor.PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { UnityEngine.Rendering.GraphicsDeviceType.Direct3D11 });
        }
        else if(RendererIndex == 1)
        {
            Debug.Log("Set to DX12");
            UnityEditor.PlayerSettings.SetGraphicsAPIs(BuildTarget.StandaloneWindows64, new[] { UnityEngine.Rendering.GraphicsDeviceType.Direct3D12 });
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
    }
}