using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    [Space]
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, CaptionsDropdown;
    public TextMeshProUGUI VolumePercentageText, MouseSensText, FovText;
    [Space]
    public Camera Camera;
    public PlayerLook PlayerLook;
    [Space]
    public UniversalAdditionalCameraData URPCamData;
    public UniversalRenderPipelineAsset URPAsset;
    public AudioMixer MainVolume;
    [Space]
    private int AntiAliasingMode, QualityMode, MsaaValue, MouseSensitivity, QualityGroup;
    private float MouseSensitivityValue, VolumeValue, FovValue;

    private void Start()
    {
        AntiAliasingDropdown.onValueChanged.AddListener(delegate
        {
            SetAntiAliasing();
        });

        QualityDropdown.onValueChanged.AddListener(delegate
        {
            SetQuality();
        });
        LoadSettingsValues();
    }

    public void LoadSettingsValues()
    {
        // Load volume value from a previous session
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume");
        SetVolume(VolumeSlider.value);

        // Load Mouse Sensitivity from a previous session
        MouseSensSlider.value = PlayerPrefs.GetFloat("MouseSensitivityValue");
        SetMouseSensitivty(MouseSensSlider.value);

        // Load FOV from a previous session
        FovSlider.value = PlayerPrefs.GetFloat("Fov");
        SetCameraFov(FovSlider.value);

        // Load Quality Mode from a previous session
        QualityDropdown.value = PlayerPrefs.GetInt("QualityLevel");
        SetQuality();

        // Load Anti-Aliasing mode from a previous session
        AntiAliasingDropdown.value = PlayerPrefs.GetInt("AntiAliasing");
        SetAntiAliasing();
    }

    public void SetVolume(float volume)
    {
        int TextDisplayVolume = Mathf.FloorToInt(volume * 100);
        // "Volume" Is an exposed value in the main audio mixer
        MainVolume.SetFloat("Volume", Mathf.Log10(volume) * 20);
        VolumePercentageText.text = TextDisplayVolume.ToString() + "%";
        PlayerPrefs.SetFloat("Volume", volume);

        ///Debug.Log("Set volume to" + volume * 100);
    }

    public void SetMouseSensitivty(float MouseSens)
    {
        // Stolen code from the old SettingsMenu.cs script. It should work
        PlayerLook.setMouseSensitivity(MouseSens);
        if (MouseSensSlider.value != MouseSens)
        {
            MouseSensSlider.value = MouseSens;
        }

        MouseSensText.text = Mathf.CeilToInt(MouseSens).ToString();
        PlayerPrefs.SetFloat("MouseSensitivityValue", MouseSens);
    }

    public void SetCameraFov(float CameraFov)
    {
        Camera.fieldOfView = CameraFov;
        FovText.text = Mathf.FloorToInt(CameraFov).ToString();
        PlayerPrefs.SetFloat("Fov", CameraFov);
    }

    public void SetQuality()
    {
        // Quality Mode is based off of how the quality is ordered in the project settings

        QualityMode = QualityDropdown.value;
        // Debug.Log("Setting Quality to " + QualitySettings.GetQualityLevel().ToString());

        QualitySettings.SetQualityLevel(QualityDropdown.value);
        PlayerPrefs.SetInt("QualityLevel", QualityMode);
    }

    public void SetCaptions()
    {
        // For 0.4
    }

    public void SetAntiAliasing()
    {
        // Using a switch case (the value of which is decided through the Anti-Aliasing Dropdown), the Anti Aliasing gets set to either Off, FXAA, TAA, or SMAA
        AntiAliasingMode = AntiAliasingDropdown.value;
        switch (AntiAliasingMode)
        {
            case 0:
                URPCamData.antialiasing = AntialiasingMode.None;
                break;
            case 1:
                URPCamData.antialiasing = AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2:
                URPCamData.antialiasing = AntialiasingMode.TemporalAntiAliasing;
                break;
            case 3:
                URPCamData.antialiasing = AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                break;
        }
        Debug.Log("Setting Anti Aliasing to" + URPCamData.antialiasing);

        PlayerPrefs.SetInt("AntiAliasing", AntiAliasingMode);
    }

    private void SetAntiAliasingQuality()
    {
        switch (QualityGroup)
        {
            case 1:
                URPCamData.antialiasingQuality = AntialiasingQuality.Low;
                break;
            case 2:
                URPCamData.antialiasingQuality = AntialiasingQuality.Medium;
                break;
            case 3:
                URPCamData.antialiasingQuality = AntialiasingQuality.High;
                break;
        }
        PlayerPrefs.SetInt("AntiAliasingQuality", QualityGroup);
    }

    public void ShowGUI(GameObject GuiToShow)
    {
        GuiToShow.SetActive(true);
    }

    public void HideGUI(GameObject GuiToHide)
    {
        GuiToHide.SetActive(false);
    }

    public void LoadNewScene(string scene)
    {
        if (Time.timeScale != 1) // For when the method is called from the pause menu
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(scene);
        if (scene == null) { Debug.LogError("Scene not properly specified on 1 or more objects"); }
    }

    public void QuitGame()
    {
        Cursor.lockState = CursorLockMode.None;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void LoadCredits()
    {
        // Debug.Log("Loading Credits");
        SceneManager.LoadScene("Credits");
    }

    public void OpenLink(string Link)
    {
        Application.OpenURL(Link);
    }

    public void OnApplicationQuit()
    {
        // Unlock cursor before game closes
        Cursor.lockState = CursorLockMode.None;
    }
}