using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.HighDefinition;
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
    private HDAdditionalCameraData hdrpCamData;
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public Toggle SpinCameraToggle;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, UpscalingDropdown, CaptionsDropdown;
    public TextMeshProUGUI VolumePercentageText, MouseSensText, FovText;
    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu, QuitOptions;
    public Camera Camera;
    public PlayerLook playerLook;
    private int AntiAliasingMode, QualityMode, UpscalingValue, MouseSensitivity;
    private float MouseSensitivityValue, VolumeValue, FovValue;
    private bool IsRaytracingSupported;

    private void Awake()
    {
        QualityDropdown.value = QualitySettings.GetQualityLevel();
        hdrpCamData = Camera.GetComponent<HDAdditionalCameraData>();
        Debug.Log(Application.platform);

        if (Application.platform.ToString().Contains("Windows"))
        {

            // Cannot beleive I didn't know this function existed
            if (SystemInfo.supportsRayTracing)
            {
                Debug.Log("Raytracing is supported on this GPU");
                IsRaytracingSupported = true;
            }

            else
            {
                Debug.Log("Raytracing is not supported on this GPU");
                IsRaytracingSupported = false;
            }
        }
        else if (Array.Exists(new string[] { RuntimePlatform.LinuxPlayer.ToString(), RuntimePlatform.LinuxEditor.ToString(), RuntimePlatform.OSXPlayer.ToString(), RuntimePlatform.OSXEditor.ToString() }, el => el == Application.platform.ToString()))
        {
            Debug.Log("Not on Windows");
            UpscalingDropdown.interactable = false;
        }
        else
        {
            Application.Quit(); // Serious problem if someone is running this on a platform that isnt Linux, Windows, or MacOS, quit immediately
        }
    }

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
        // "Very Low" is 0 and "DXR High" is 6 (As Of 0.3.0)
        QualityMode = QualityDropdown.value;
        if (!IsRaytracingSupported && QualityDropdown.value.Either(5, 6))
        {
            // If a player without raytracing-cabable hardware tries to switch to DXR, set to "Ultra" quality instead (might be better to just return instead of doing anything lol)
            QualityDropdown.value = 4; // The function should just run again because of the listener in Start()
            Debug.Log("Player without required hardware tried to set quality to DXR Low/High. Switching back to Ultra");
            return;
        }
        Debug.Log("Setting Quality to " + QualitySettings.GetQualityLevel().ToString());
        QualitySettings.SetQualityLevel(QualityDropdown.value);
        PlayerPrefs.SetInt("QualityLevel", QualityMode);
    }

    public void SetCaptions()
    {
        // For 0.4.0
    }

    public void SetUpscaling()
    {
        // For 0.4.0. currently upscaling should in theory just automatically be on when setting a DXR profile, and should fall back to FSR 1.0 if DLSS is not supported 
    }

    public void SetAntiAliasing()
    {
        // It Sets the anti aliasing (idk how to describe it in a way for myself to understand in the future)
        AntiAliasingMode = AntiAliasingDropdown.value;
        switch (AntiAliasingMode)
        {
            case 0:
                hdrpCamData.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
                break;
            case 1:
                hdrpCamData.antialiasing = HDAdditionalCameraData.AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2:
                hdrpCamData.antialiasing = HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing;
                break;
            case 3:
                hdrpCamData.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                break;
        }
        Debug.Log("Setting AA Mode to " + hdrpCamData.antialiasing);
        PlayerPrefs.SetInt("AntiAliasing", AntiAliasingMode);
    }
    public void LoadGame()
    {
        // for 0.4.0
    }

    public void LoadNewScene(string scene)
    {
        if(Time.timeScale != 1) { Time.timeScale = 1; } // For when the function is called from the pause menu
        SceneManager.LoadScene(scene);
        if (scene == null) { Debug.LogError("Scene not properly specified on 1 or more objects"); }
    }

    public void ToggleCamSpin(bool toggled)
    {
        Camera.GetComponent<RotateCamera>().enabled = toggled;
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void LoadCredits()
    {
        Debug.Log("Loading Credits");
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