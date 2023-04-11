using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Slider fovSlider;
    public Slider msSlider;
    public GameObject optionMenu;
    public Slider volSlider;
    float fov;
    float mouseSens;
    float volume;
    public void FOV(float fov) {
        // GameObject.Find("OptionsMenu").GetComponent<CameraFOV>().setCameraFOV(fov);
        PlayerPrefs.SetFloat("CameraFOV", fov);
        optionMenu.GetComponent<CameraFOV>().setCameraFOV(fov);
        if (fovSlider.value != fov) {
            fovSlider.value = fov;
        }
    }
    public void MouseSens(float sens) {
        // GameObject.Find("OptionsMenu").GetComponent<PlayerLook>().setMouseSensitivity(sens);
        PlayerPrefs.SetFloat("MouseSens", sens);
        optionMenu.GetComponent<PlayerLook>().setMouseSensitivity(sens);
        if (msSlider.value != sens) {
            msSlider.value = sens;
        }
    }
    public void Volume(float volume) {
        audiomixer.SetFloat("Volume", volume * volume * volume / 6400);
        // audiomixer.SetFloat("Volume", volume * volume * volume * volume / -512000);
        PlayerPrefs.SetFloat("Volume", volume);
        if (volSlider.value != volume) {
            volSlider.value = volume;
        }
    }
    void Start()
    {
        fov = PlayerPrefs.GetFloat("CameraFOV", 60);
        mouseSens = PlayerPrefs.GetFloat("MouseSens", 80);
        volume = PlayerPrefs.GetFloat("Volume", -5);

        FOV(fov);
        MouseSens(mouseSens);
        Volume(volume);
    }
}