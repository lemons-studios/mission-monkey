using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestoreOptionsValuesOnLoad : MonoBehaviour
{
    public TMP_Dropdown qualityDropdownm, aaModeDropdown, aaQualityDropdown, captionsDropdown;
    public Slider volumeSlider, fovSlider, mouseSensitivitySlider;

    private void Awak() 
    {
        qualityDropdownm.value = PlayerPrefs.GetInt("GraphicsQuality");
        aaModeDropdown.value = PlayerPrefs.GetInt("AntiAliasingMode");
        aaQualityDropdown.value = PlayerPrefs.GetInt("AntiAliasingQuality");
        captionsDropdown.value = PlayerPrefs.GetInt("SubtitlesMode");

        volumeSlider.value = PlayerPrefs.GetFloat("Volume") / 100;
        fovSlider.value = PlayerPrefs.GetFloat("FieldOfView");
        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity");
    }
}
