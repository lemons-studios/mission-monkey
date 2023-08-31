using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public HDRenderPipelineAsset[] QualityProfiles;
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public Toggle SpinCameraToggle;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, DLSSDropdown;
    public TextMeshProUGUI VolumePercentageText, MouseSensText, FovText;
    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu;
    public Camera Camera;
    public int MouseSensitivity;
    private int AntiAliasingMode, IsRaytracingOn, QualityMode;
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

    public void SetQuality(int QualityLevel)
    {
        QualitySettings.SetQualityLevel(QualityLevel, true);
        PlayerPrefs.SetInt("QualityMode", QualityLevel);
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
        if(MouseSensSlider.value != MouseSens) 
        {
            MouseSensSlider.value = MouseSens;
        }
    }

    public void SetAntiAliasing(int AntiAliasingIndex)
    {

    }

    public void SetRaytracing(int RayTracingIndex)
    {
        if (!IsRaytracingSupported) return; // Just in case someone somehow manages to interact with the disabled dropdown menu so nothing happens and their computer does not blow up (probably useless but just in case)
    }

    public void SetDLSS(int DLSSIndex)
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