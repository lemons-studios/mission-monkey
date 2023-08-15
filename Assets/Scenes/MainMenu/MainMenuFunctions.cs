using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, RayTracingDropdown;
    public TextMeshProUGUI VolumePercentage, MouseSens;
    public GameObject MainMenu, OptionsMenu, ChapterSelectMenu, LoadGameMenu;
    public int MouseSensitivity;
    private int AntiAliasingMode, IsRaytracingOn, QualityMode;
    private float MouseSensitivityValue, VolumeValue, FovValue;
    
    private bool HasRaytracing()
    {
        if (SystemInfo.graphicsDeviceName.Contains("RTX")) // Checks if the name of the graphics card contains the word "RTX"
        {
            Debug.Log("This Computer Supports Raytracing");
            IsRaytracingOn = 1;
            return true;
        }
        else Debug.Log("This Computer DOES NOT Support Raytracing"); 
        IsRaytracingOn = 0;
        return false;
    }
    void Awake()
    {
        // Clamp the minimum mouse sensitivity to 30, and the max to 125 (Change if required later)
        Mathf.Clamp(MouseSensitivity, 30, 125);

        // If the computer does not support raytracing/has an NVIDIA RTX card, disable the dropdown for raytracing to prevent it from being on. also set raytracing off if for some reason it is on
        if(!HasRaytracing())
        {
            RayTracingDropdown.interactable = false;
        }

        // If QualityMode is 0, It would be the first launch of the game, set the default quality to "Medium"
        if(QualityMode == 0)
        {
            PlayerPrefs.SetInt("QualityMode", 2);
            QualitySettings.SetQualityLevel(QualityMode);
        }
    }

    public void QualitySelect()
    {

    }
    public void SetVolume(float volume)
    {
        // Set volume based on value of the slider
        MainVolume.SetFloat("Volume", Mathf.Pow(volume, 3) / 6400);
        // Remember what the value was set to so it remains the same between sessions
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetMouseSensitivty()
    {

    }
    public void SetAntiAliasing(int AntiAliasingIndex)
    {

    }
    public void SetRaytracing(int RayTracingIndex) 
    {

    }
    public void MenuToSettings()
    {
        // Disable the main menu gui and show the settings gui
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void SettingsToMenu()
    {
        // The reverse of MenuToSettings()
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void ShowChapterSelect()
    {
        // Enable the GameObject containing all of the chapter select GameObjects
        ChapterSelectMenu.SetActive(true);
    }
    public void LoadIntoChapter(int chapter)
    {
        SceneManager.LoadScene("Chapter" + chapter + "-1");
    }
    public void HideChapterSelect()
    {
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