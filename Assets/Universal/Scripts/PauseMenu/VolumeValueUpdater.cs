using UnityEngine;
using UnityEngine.Audio;
using TMPro;


public class VolumeValueUpdater : MonoBehaviour
{
    public TextMeshProUGUI VolumeValue;
    public AudioMixer VolumeMixer;
    float Volume;

    private void Update()
    {
        float volumeInDecibels;
        VolumeMixer.GetFloat("Volume", out volumeInDecibels);
        float LinearVolume = DbToLinear(volumeInDecibels);
        VolumeValue.text = (LinearVolume * 100).ToString("F0") + "%";
    }

    float DbToLinear(float dbValue) {
        float minimumDb = -80f;
        float maximumDb = 0.16f;
        float normalizedDb = Mathf.InverseLerp(minimumDb, maximumDb, dbValue);
        return Mathf.Pow(10, (dbValue /20));
    }
}
