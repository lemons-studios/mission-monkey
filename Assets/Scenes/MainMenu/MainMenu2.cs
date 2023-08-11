using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuV2 : MonoBehaviour
{
    public AudioMixer MainVolume;
    public Slider VolumeSlider, MouseSensSlider, FovSlider;
    public TMP_Dropdown QualityDropdown, AntiAliasingDropdown, RayTracingDropdown;
    public TextMeshProUGUI VolumePercentage, MouseSens;
    private int QualityMode, AntiAliasingMode, IsRaytracingOn;
    private float MouseSensitivityValue, VolumeValue, FovValue;
    
    private bool HasRaytracing()
    {
        if (SystemInfo.graphicsDeviceName.Contains("RTX"))
        {
            Debug.Log("This Computer Supports Raytracing");
            return true;
        }
        else Debug.Log("This Computer DOES NOT Support Raytracing"); 
        return false;
        
    }
    private void Start()
    {
        if(!HasRaytracing())
        {
            RayTracingDropdown.interactable = false;
        }
    }
    public void QualitySelect()
    {

    }
    public void SetVolume(float volume)
    {
        MainVolume.SetFloat("Volume", Mathf.Pow(volume, 3) / 6400);
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetAntiAliasing()
    {

    }
    public void SetRaytracing(int RayTracingIndex) 
    {

    }
    public void MenuToSettings()
    {

    }
    public void SettingsToMenu()
    {

    }
    public void ShowChapterSelect()
    {

    }
    public void LoadIntoChapter()
    {

    }
    public void HideChapterSelect()
    {

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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }
}