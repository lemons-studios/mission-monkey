using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class ObjectExtensions
{
    // https://stackoverflow.com/questions/3870263/how-can-i-write-like-x-either-1-or-2-in-a-programming-language 
    public static bool Either(this object value, params object[] array)
    {
        return array.Any(p => Equals(value, p));
    }
}

public class MainMenuFunctions : MonoBehaviour
{
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public Toggle SpinCameraToggle;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, CaptionsDropdown;
    public TextMeshProUGUI VolumePercentageText, MouseSensText, FovText;

    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu, QuitOptions, SaveGameMenu;
    public Camera Camera;
    public PlayerLook playerLook;
    public UniversalAdditionalCameraData URPCamData;
    public UniversalRenderPipelineAsset URPAsset;

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

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

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
        playerLook.setMouseSensitivity(MouseSens);
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

        if (AntiAliasingMode == 3)
        {
            DetermineQualityGroup();
            SetAntiAliasingQuality();
        }
    }

    public void SetCaptions()
    {
        // For 0.4.0

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

    private void DetermineQualityGroup()
    {
        if (QualityMode <= 1) // Very low and low quality profiles
        {
            QualityGroup = 1;
        }
        else if (QualityMode <= 3) // Medium and high quality profiles
        {
            QualityGroup = 2;
        }
        else if (QualityMode >= 4) // Ultra quality profiles
        {
            QualityGroup = 3;
        }
    }

    public void LoadGame()
    {
        // actual code for 0.4.0 for now, show GUI that says that the feature is under construction
        LoadGameMenu.SetActive(true);
    }

    public void HideLoadGameGUI()
    {
        LoadGameMenu.SetActive(false);
    }

    public void SaveGame()
    {
        // Like LoadGame(), Actual code will be implemented in 0.4.0, but for now, only the GUI will show
        SaveGameMenu.SetActive(true);
    }

    public void HideOtherGUI(GameObject GUI)
    {
        GUI.SetActive(false);
    }


    public void LoadNewScene(string scene)
    {
        if (Time.timeScale != 1) { Time.timeScale = 1; } // For when the function is called from the pause menu
        SceneManager.LoadScene(scene);
        if (scene == null) { Debug.LogError("Scene not properly specified on 1 or more objects"); }
    }

    public void ToggleCamSpin(bool toggled)
    {
        Camera.GetComponent<RotateCamera>().enabled = toggled; // This might get removed in the future
    }

    public void MenuToSettings()
    {
        // Hide the main menu gui and show the settings gui
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void SettingsToMenu()
    {
        // Reverse of MenuToSettings()
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ShowChapterSelect()
    {
        // Show chapter select GUI
        ChapterSelectMenu.SetActive(true);
    }

    public void HideChapterSelect()
    {
        // Hide the chapter select GUI
        ChapterSelectMenu.SetActive(false);
    }

    // Pause Menu Functions
    public void ShowQuitOptions()
    {
        QuitOptions.SetActive(true);
    }

    public void HideQuitOptions()
    {
        QuitOptions.SetActive(false);
    }

    public void LoadToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
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

    public void OpenGHPage()
    {
        Application.OpenURL("https://github.com/Lemons-Studios/Mission-Monkey");
    }

    public void OnApplicationQuit()
    {
        // Unlock cursor before game closes
        Cursor.lockState = CursorLockMode.None;
    }
}