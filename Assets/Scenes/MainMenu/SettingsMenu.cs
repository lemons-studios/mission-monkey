using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Slider msSlider;
    public GameObject optionMenu;
    public TMP_Dropdown qualitySelect;
    public Slider volSlider;
    float mouseSens, volume;
    public static float publicFOV, publicMouseSens, publicVolume;
    int quality;

/*    public void FOV(float fov)
    {
        // GameObject.Find("OptionsMenu").GetComponent<CameraFOV>().setCameraFOV(fov);
        PlayerPrefs.SetFloat("CameraFOV", fov);
        optionMenu.GetComponent<CameraFOV>().setCameraFOV(fov);
        if (fovSlider.value != fov)
        {
            fovSlider.value = fov;
        }
    }
    */
    public void MouseSens(float sens)
    {
        // GameObject.Find("OptionsMenu").GetComponent<PlayerLook>().setMouseSensitivity(sens);
        PlayerPrefs.SetFloat("MouseSens", sens);
        optionMenu.GetComponent<PlayerLook>().setMouseSensitivity(sens);
        if (msSlider.value != sens)
        {
            msSlider.value = sens;
        }
    }
    public void Quality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
        PlayerPrefs.SetInt("Quality", index);
        if (qualitySelect.value != index)
        {
            qualitySelect.value = index;
        }
    }
    public void Volume(float volume)
    {
        audiomixer.SetFloat("Volume", volume * volume * volume / 6400);
        // audiomixer.SetFloat("Volume", volume * volume * volume * volume / -512000);
        PlayerPrefs.SetFloat("Volume", volume);
        if (volSlider.value != volume)
        {
            volSlider.value = volume;
        }
    }
    void Start()
    {
        // fov = PlayerPrefs.GetFloat("CameraFOV", 60);
        mouseSens = PlayerPrefs.GetFloat("MouseSens", 80);
        quality = PlayerPrefs.GetInt("Quality", 4);
        volume = PlayerPrefs.GetFloat("Volume", -5);

        // FOV(fov);
        MouseSens(mouseSens);
        Quality(quality);
        Volume(volume);
    }
}