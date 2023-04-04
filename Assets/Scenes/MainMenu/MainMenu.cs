using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("Prototyping Scene");
    }
    public void Quit() {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
