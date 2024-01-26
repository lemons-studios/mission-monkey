using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    private Camera mainCamera;
    private UniversalAdditionalCameraData urpCamData;
    public PlayerCamera playerCamera;
    public AudioMixer mainVolume;
    public TextMeshProUGUI volumeValueText, mouseSensitivityValueText, fieldOfViewValueText;

    private void Awake()
    {
        mainCamera = Camera.main;
        urpCamData = mainCamera.GetComponent<UniversalAdditionalCameraData>();
    }
    
    private void Start() 
    {
        SetOptionsFromPlayerPrefs();
    }

    private void SetOptionsFromPlayerPrefs()
    {
        SetGraphicsQuality(PlayerPrefs.GetInt("GraphicsQuality"));
        SetAntiAliasingMode(PlayerPrefs.GetInt("AntiAliasingMode"));
        SetAntiAliasingQuality(PlayerPrefs.GetInt("AntiAliasingQuality"));
        SetSubtitles(PlayerPrefs.GetInt("SubtitlesMode"));
        SetVolume(PlayerPrefs.GetFloat("Volume"));
        SetFieldOfView(PlayerPrefs.GetFloat("FieldOfView"));
        SetMouseSensitivity(PlayerPrefs.GetFloat("MouseSensitivity"));
    }


    public void SetGraphicsQuality(int newQualityLevel)
    {
        QualitySettings.SetQualityLevel(newQualityLevel);
        PlayerPrefs.SetInt("GraphicsQuality", newQualityLevel);
    }

    public void SetAntiAliasingMode(int newAntiAliasingMode)
    {
        switch(newAntiAliasingMode)
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
        switch(newAAQuality)
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

        int TextDisplayVolume = Mathf.RoundToInt(volume * 100);
        volumeValueText.text = TextDisplayVolume + "%";
    }

    public void SetMouseSensitivity(float newMouseSensitivity)
    {
        int roundedMouseSensitivity = Mathf.RoundToInt(newMouseSensitivity);
        if(playerCamera != null)
        {
            playerCamera.SetSensitivity(roundedMouseSensitivity);
        }

        PlayerPrefs.SetFloat("MouseSensitivity", roundedMouseSensitivity);
        mouseSensitivityValueText.text = roundedMouseSensitivity.ToString();
    }

    public void SetFieldOfView(float newFovValue)
    {
        if(playerCamera != null)
        {
            mainCamera.fieldOfView = newFovValue;
        }
        
        PlayerPrefs.SetFloat("FieldOfView", newFovValue);
        int roundedFovValue = Mathf.RoundToInt(newFovValue);
        fieldOfViewValueText.text = roundedFovValue.ToString();
    }
}
