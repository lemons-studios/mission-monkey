using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public int Chapter1 = 1;
    public int Mainmenu = 0;
    public void Load(){

    }
    public void Play(int scene){
        SceneManager.LoadScene(scene);
    }
    public void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void QuitToMenu() {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(Mainmenu);
    }

}

