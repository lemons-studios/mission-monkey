using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, RayTracingDropdown;
    public TextMeshProUGUI VolumePercentage, MouseSens;
    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu;
    public Camera Camera;
    public int MouseSensitivity;
    private int AntiAliasingMode, IsRaytracingOn, QualityMode, isFirstLaunch;
    private float MouseSensitivityValue, VolumeValue, FovValue;
    private string FirstLaunchCheck = @".\FirstLaunchCheckDoNotDelete";

    private bool HasRaytracing()
    {
        if (SystemInfo.graphicsDeviceName.Contains("RTX")) // Checks if the name of the graphics card contains the word "RTX" (Sorry AMD users, I'm a lazy fucker)
        {
            Debug.Log("This Computer Supports Raytracing");
            return true;
        }
        else Debug.Log("This Computer DOES NOT Support Raytracing");
        // If the computer does not support raytracing/has an NVIDIA RTX card, disable the dropdown for raytracing to prevent it from being on. also set raytracing off if for some reason it is on
        RayTracingDropdown.interactable = false;
        return false;
    }
    void Awake()
    {
        string FirstLaunchCheck = @".\FirstLaunch";
        // Clamp the minimum mouse sensitivity to 30, and the max to 125 (Change if required later)
        Mathf.Clamp(MouseSensitivity, 30, 125);
        // If QualityMode is 0, It would be the first launch of the game, set the default quality to "Medium"
        if (QualityMode == 0)
        {
            PlayerPrefs.SetInt("QualityMode", 2);
            QualitySettings.SetQualityLevel(QualityMode);
        }
        if (!File.Exists(FirstLaunchCheck))
        {
            SetDefaultValues();
        }
    }
    private void SetDefaultValues()
    {
        var HdrpAsset = GraphicsSettings.currentRenderPipeline as HDRenderPipelineAsset;
        // Default values for settings
        PlayerPrefs.SetInt("isFirstLaunch", 1);
        PlayerPrefs.SetInt("MouseSensitivityValue", 55);
        PlayerPrefs.SetInt("VolumeValue", 100);

        // Disable Raytracing by default
        RenderPipelineSettings RtxSettings = HdrpAsset.currentPlatformRenderPipelineSettings;
        RtxSettings.supportRayTracing = false;
        HdrpAsset.currentPlatformRenderPipelineSettings = RtxSettings;

        // Create the file
        File.Create(FirstLaunchCheck);
    }
    public void QualitySelect(int QualityLevel)
    {

    }
    public void SetVolume(float volume)
    {
        // ChakornK did the math on the previous script and I stole it because im lazy. will update later if i figure it out
        // It supposedly changes slider value distribution
        MainVolume.SetFloat("Volume", Mathf.Pow(volume, 3) / 6400);
        // Remember what the value was set to so it remains the same between sessions
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetMouseSensitivty()
    {

    }
    public void SetAntiAliasing(int AntiAliasingIndex)
    {
        QualitySettings.antiAliasing = AntiAliasingIndex;
    }
    public void SetRaytracing(int RayTracingIndex)
    {
        Mathf.Clamp(RayTracingIndex, 0, 1); // Clamp the index so the game does not crash 
        // Just in case the player whos computer does not support raytracing somehow manages to change the dropdown value
        if (!HasRaytracing())
        {
            return;
        }
        var HdrpAsset = GraphicsSettings.currentRenderPipeline as HDRenderPipelineAsset;
        if (HdrpAsset == null)
        {
            Debug.LogError("HdrpAsset Not Found! Something is seriously wrong!!");
        }
        // It does stuff
        if (RayTracingIndex == 0)
        {
            RenderPipelineSettings RtxSettings = HdrpAsset.currentPlatformRenderPipelineSettings;
            RtxSettings.supportRayTracing = false;
            HdrpAsset.currentPlatformRenderPipelineSettings = RtxSettings;
        }
        else if (RayTracingIndex == 0)
        {
            RenderPipelineSettings RtxSettings = HdrpAsset.currentPlatformRenderPipelineSettings;
            RtxSettings.supportRayTracing = true;
            HdrpAsset.currentPlatformRenderPipelineSettings = RtxSettings;
        }
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
    public void LoadIntoChapter(int chapter)
    {
        // Loads into chapter that is selected based off of what chapter int returns
        SceneManager.LoadScene("Chapter" + chapter + "-1");
    }
    public void HideChapterSelect()
    {
        // Hide the chapter select GUI
        ChapterSelectMenu.SetActive(false);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void OnApplicationQuit()
    {
        // Unlock cursor before game closes
        Cursor.lockState = CursorLockMode.None;
    }
}