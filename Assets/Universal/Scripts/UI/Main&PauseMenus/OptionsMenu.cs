using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mainVolume;
    public Camera mainCamera;
    public TextMeshProUGUI volumeValueText, mouseSensitivityValueText, fieldOfViewValueText;
    public TMP_Dropdown qualityDropdown, aaModeDropdown, aaQualityDropdown, captionsDropdown;
    public Slider volumeSlider, fovSlider, mouseSensitivitySlider;
    private PlayerCamera playerCamera;
    private UniversalAdditionalCameraData urpCamData;
    private UniversalRenderPipelineAsset urpAsset;

    private void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null) return;
        playerCamera = mainCamera.GetComponentInParent<PlayerCamera>();
        urpCamData = mainCamera.GetComponent<UniversalAdditionalCameraData>();

        SetOptionsFromPlayerPrefs();
    }

    private void SetOptionsFromPlayerPrefs()
    {
        qualityDropdown.value = PlayerPrefs.GetInt("GraphicsQuality");
        SetGraphicsQuality(qualityDropdown.value);

        aaModeDropdown.value = PlayerPrefs.GetInt("AntiAliasingMode");
        SetAntiAliasingMode(aaModeDropdown.value);

        aaQualityDropdown.value = PlayerPrefs.GetInt("AntiAliasingQuality");
        SetAntiAliasingQuality(aaQualityDropdown.value);

        captionsDropdown.value = PlayerPrefs.GetInt("SubtitlesMode");
        SetSubtitles(captionsDropdown.value);

        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        SetVolume(volumeSlider.value);

        fovSlider.value = PlayerPrefs.GetFloat("FieldOfView");
        SetFieldOfView(fovSlider.value);

        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
        SetMouseSensitivity(mouseSensitivitySlider.value);
    }

    public void SetGraphicsQuality(int newQualityLevel)
    {
        QualitySettings.SetQualityLevel(newQualityLevel);
        PlayerPrefs.SetInt("GraphicsQuality", newQualityLevel);
    }

    public void SetAntiAliasingMode(int newAntiAliasingMode)
    {
        switch (newAntiAliasingMode)
        {
            case 0:     // OFF
                urpCamData.antialiasing = AntialiasingMode.None;
                break;
            case 1:     // FXAA
                urpCamData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2:     // TAA
                urpCamData.antialiasing = AntialiasingMode.TemporalAntiAliasing;
                break;
            case 3:     // SMAA
                urpCamData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                break;
        }

        PlayerPrefs.SetInt("AntiAliasingMode", newAntiAliasingMode);
    }

    public void SetAntiAliasingQuality(int newAAQuality)
    {
        switch (newAAQuality)
        {
            case 0:
                urpCamData.antialiasingQuality = AntialiasingQuality.Low;
                break;
            case 1:
                urpCamData.antialiasingQuality = AntialiasingQuality.Medium;
                break;
            case 2:
                urpCamData.antialiasingQuality = AntialiasingQuality.High;
                break;
        }
        PlayerPrefs.SetInt("AntiAliasingQuality", newAAQuality);
    }

    public void SetSubtitles(int subtitlesMode)
    {
        // WIP
        PlayerPrefs.SetInt("SubtitlesMode", subtitlesMode);
    }

    public void SetVolume(float volume)
    {
        mainVolume.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);

        int textDisplayVolume = Mathf.RoundToInt(volume * 100);
        volumeValueText.text = textDisplayVolume + "%";
    }

    public void SetMouseSensitivity(float newMouseSensitivity)
    {
        int roundedMouseSensitivity = Mathf.RoundToInt(newMouseSensitivity);
        if (playerCamera != null)
        {
            playerCamera.SetSensitivity(roundedMouseSensitivity);
        }

        mouseSensitivityValueText.text = roundedMouseSensitivity.ToString();
        PlayerPrefs.SetFloat("MouseSensitivity", roundedMouseSensitivity);
    }

    public void SetFieldOfView(float newFovValue)
    {
        if (mainCamera != null)
        {
            mainCamera.fieldOfView = newFovValue;
        }
        int roundedFovValue = Mathf.RoundToInt(newFovValue);
        fieldOfViewValueText.text = roundedFovValue.ToString();

        PlayerPrefs.SetFloat("FieldOfView", newFovValue);
    }
}
