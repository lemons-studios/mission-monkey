using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
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
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, DLSSDropdown;
    public TextMeshProUGUI VolumePercentageText, MouseSensText, FovText;
    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu;
    public Camera Camera;
    public int MouseSensitivity;
    private int AntiAliasingMode, IsRaytracingOn, QualityMode, DLSSValue;
    private float MouseSensitivityValue, VolumeValue, FovValue;
    private bool IsRaytracingSupported;


    // private string[] OtherSupportedPlatforms = { "LinuxEditor", "LinuxPlayer", "OSXPlayer", "OSXEditor"}; 

    private bool IsDlssSupported()
    {
        if (SystemInfo.graphicsDeviceName.ToString().Contains("RTX"))
        {
            // All RTX Gpus have DLSS. Yes i know about the 16 series also having DLSS 1 but i'm too lazy to check for them so GTX 16 series users should use FSR instead
            Debug.Log("This Computer Supports DLSS");
            return true;
        }
        else return false;
    }

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

            if (!IsDlssSupported())
            {
                DLSSDropdown.interactable = false;
            }
        }
        else if (Array.Exists(new string[] { RuntimePlatform.LinuxPlayer.ToString(), RuntimePlatform.LinuxEditor.ToString(), RuntimePlatform.OSXPlayer.ToString(), RuntimePlatform.OSXEditor.ToString() }, el => el == Application.platform.ToString()))
        {
            Debug.Log("Not on Windows");
            DLSSDropdown.interactable = false;
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
    }



    public void SetVolume(float volume)
    {
        /// ChakornK did the math on the previous script and I stole it because im lazy. will update later if i figure it out
        /// It supposedly changes slider value distribution
        MainVolume.SetFloat("Volume", Mathf.Pow(volume, 3) / 6400);
        // Remember what the value was set to so it remains the same between sessions
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void SetMouseSensitivty(float MouseSens)
    {
        // Stolen code from the old SettingsMenu.cs script. It should work
        PlayerPrefs.SetFloat("MouseSensitivityValue", MouseSens);
        Camera.GetComponent<PlayerLook>().setMouseSensitivity(MouseSens);
        if (MouseSensSlider.value != MouseSens)
        {
            MouseSensSlider.value = MouseSens;
        }
    }
    public void SetQuality()
    {
        // Quality Mode is based off of how the quality is ordered in the project settings
        // "Very Low" is 0 and "DXR High" is 6 (As Of 0.3.0)
        QualityMode = QualityDropdown.value;
        Debug.Log("Setting Quality to " + QualitySettings.GetQualityLevel());
        if (!IsRaytracingSupported && QualityDropdown.value.Either(5,6))
        {
            // If a player without raytracing-cabable hardware tries to switch to DXR, set to "Ultra" quality instead (might be better to just return instead of doing anything lol)
            QualitySettings.SetQualityLevel(4) /*4 would be Ultra*/ ;
            return;
        }
        QualitySettings.SetQualityLevel(QualityDropdown.value);

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
    }

    public void SetRaytracing()
    {
        if (!IsRaytracingSupported) return; // Just in case someone somehow manages to interact with the disabled dropdown menu so nothing happens and their computer does not blow up (probably useless but just in case)
    }

    public void SetDLSS()
    {
        if (!IsDlssSupported()) return; // Literally the exact same reason as above
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
    public void ToggleCamSpin(bool toggled)
    {
        Camera.GetComponent<RotateCamera>().enabled = toggled;
    }

    public void LoadNewScene(string scene)
    {
        SceneManager.LoadScene(scene);
        if (scene == null) { Debug.LogError("Scene not properly specified on 1 or more objects"); }
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