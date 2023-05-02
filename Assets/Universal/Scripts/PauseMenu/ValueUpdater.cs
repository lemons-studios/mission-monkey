using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class ValueUpdater : MonoBehaviour
{
    public Camera fovCam;
    public AudioMixer VolumeMixer;
    public TextMeshProUGUI VolumeValue;
    public TextMeshProUGUI MouseSensValue;
    public TextMeshProUGUI fovValue;


    void Update()
    {
        UpdateVolumePercentage();
        UpdateMouseSensValue();
        UpdateFOVValue();
    }
    public void UpdateVolumePercentage()
    {
        float volumeInDecibels;
        VolumeMixer.GetFloat("Volume", out volumeInDecibels);
        float LinearVolume = DbToLinear(volumeInDecibels);
        VolumeValue.text = (LinearVolume * 100).ToString("F0") + "%";
    }
    public void UpdateMouseSensValue()
    {
        MouseSensValue.text = PlayerLook.averagedSens.ToString();
    }
    public void UpdateFOVValue()
    {
        fovValue.text = fovCam.fieldOfView.ToString() + "°";
    }
    float DbToLinear(float dbValue)
    {
        float minimumDb = -80f;
        float maximumDb = 0f;
        float normalizedDb = Mathf.InverseLerp(minimumDb, maximumDb, dbValue);
        return Mathf.Pow(10, (dbValue / 20));
    }

}
