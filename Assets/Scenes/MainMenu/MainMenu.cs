using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public int Chapter1 = 1;
    public void Load(){

    }
    public void Play(){
        SceneManager.LoadScene(Chapter1);
    }
    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

