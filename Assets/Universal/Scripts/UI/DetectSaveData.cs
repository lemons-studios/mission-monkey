using UnityEngine;
using LemonStudios.CsExtensions;
using System.IO;
using UnityEngine.SceneManagement;

public class DetectSaveData : MonoBehaviour
{
    public SaveData saveData;
    public void NewGameMenuLogic(GameObject newGameUI)
    {
        if(!LemonStudiosCsExtensions.DoesFileExist(Path.Combine(Application.persistentDataPath, "missionMonkeyData.json")))
        {
            SceneManager.LoadScene("Chapter1");
        }
        else
        {
            newGameUI.SetActive(true);
        }
    } 

    public void StartNewGame()
    {
        saveData.DeleteSaveData();
        SceneManager.LoadScene("Chapter1");
    }
}
