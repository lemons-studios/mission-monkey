using System;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ValueUpdater : MonoBehaviour
{
    public AudioMixer VolumeMixer;
    public TextMeshProUGUI VolumeValue;
    public TextMeshProUGUI MouseSensValue;
    public Slider volSlider;

    void Update()
    {
        UpdateVolumePercentage();
        UpdateMouseSensValue();
    }
    public void UpdateVolumePercentage()
    {
        VolumeValue.text = (Math.Round((volSlider.value + 80) * 10 / 9)).ToString("F0") + "%";
    }
    public void UpdateMouseSensValue()
    {
        MouseSensValue.text = PlayerLook.averagedSens.ToString();
    }
}
