using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public HDRenderPipelineAsset RaytracingOnAsset, RaytracingOffAsset;
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, RayTracingDropdown;
    public TextMeshProUGUI VolumePercentage, MouseSens;
    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu;
    public Camera Camera;
    public int MouseSensitivity;
    private int AntiAliasingMode, IsRaytracingOn, QualityMode;
    private float MouseSensitivityValue, VolumeValue, FovValue;
    private bool IsRaytracingSupported;

    private void Awake()
    {
        // Cannot beleive I didn't know this function existed
       /* if (SystemInfo.supportsRayTracing)
        {
            Debug.Log("Raytracing is supported on this GPU");
            IsRaytracingSupported = true;
            GraphicsSettings.renderPipelineAsset = RaytracingOnAsset;
        }
        else
        {
            Debug.Log("Raytracing is not supported on this GPU");
            IsRaytracingSupported = false;
            RayTracingDropdown.interactable = false;
            GraphicsSettings.renderPipelineAsset = RaytracingOffAsset;
        } */
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