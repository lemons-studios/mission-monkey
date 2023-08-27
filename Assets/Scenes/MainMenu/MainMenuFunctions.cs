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
    private int AntiAliasingMode, IsRaytracingOn, QualityMode;
    private float MouseSensitivityValue, VolumeValue, FovValue;

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
    private void Awake()
    {
        HasRaytracing();
    }
    public void QualitySelect(int QualityLevel)
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
        PlayerPrefs.SetFloat("MouseSensitivityValue", MouseSens);
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
        PlayerPrefs.SetInt("IsRaytracingOn", RayTracingIndex);
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