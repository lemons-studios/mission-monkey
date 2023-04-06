using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void Volume(float volume) {
        audiomixer.SetFloat("Volume", volume);
    }
}