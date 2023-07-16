using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class OptionsMenu2 : MonoBehaviour
{
    public Canvas OptionsCanvas;
    public TMP_Dropdown QualityDd, AntiAliasingDd, RendererDd, RaytracingDd, DlssDd;
    public Slider VolumeSlider, FovSlider;
    public void Start()
    {
        
    }
    public void SetRenderer()
    {

    }
    public void QuitGame()
    {
#if UNITY_EDITOR

#endif
        Application.Quit();
    }
}
