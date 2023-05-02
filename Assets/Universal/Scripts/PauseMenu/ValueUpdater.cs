using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class ValueUpdater : MonoBehaviour
{
    public AudioMixer VolumeMixer;
    public TextMeshProUGUI VolumeValue;
    public TextMeshProUGUI MouseSensValue;


    void Update()
    {
        UpdateVolumePercentage();
        UpdateMouseSensValue();
    }
    public void UpdateVolumePercentage()
    {
        float volumeInDecibels;
        VolumeMixer.GetFloat("Volume", out volumeInDecibels);
        float LinearVolume = DbToLinear(volumeInDecibels);
        VolumeValue.text = (LinearVolume * 10000 / 102 ).ToString("F0") + "%";
    }
    public void UpdateMouseSensValue()
    {
        MouseSensValue.text = PlayerLook.averagedSens.ToString();
    }
    float DbToLinear(float dbValue)
    {
        float minimumDb = -80f;
        float maximumDb = 0f;
        float normalizedDb = Mathf.InverseLerp(minimumDb, maximumDb, dbValue);
        return Mathf.Pow(10, (dbValue / 20));
    }

}
