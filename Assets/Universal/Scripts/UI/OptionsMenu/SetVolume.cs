using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer MusicMixer;

    private void Start() 
    {
        ChangeVolume(PlayerPrefs.GetFloat("Volume"));    
    }

    public void ChangeVolume(float newVolume)
    {
        // Stolen from 0.3 main menu script
        // I still have no clue how this works entirely. All I do know is that it DOES work
        MusicMixer.SetFloat("Volume", Mathf.Log10(newVolume) * 20);
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}
