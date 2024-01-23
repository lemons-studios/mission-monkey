using UnityEngine;

public class OtherOptions : MonoBehaviour
{
    public SaveData saveData;

    public void HideUI(GameObject uiToHide)
    {
        uiToHide.SetActive(false);
    }

    public void ShowUI(GameObject uiToShow)
    {
        uiToShow.SetActive(true);
    }

    public void QuitGame()
    {
        Cursor.lockState = CursorLockMode.None;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
