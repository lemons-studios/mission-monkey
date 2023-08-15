using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private int Chapter1 = 1;
    private int Mainmenu = 0;
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
