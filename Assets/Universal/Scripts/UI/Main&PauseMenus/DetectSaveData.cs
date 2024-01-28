using UnityEngine;
using LemonStudios.CsExtensions;
using System.IO;

public class DetectSaveData : MonoBehaviour
{
    public SaveData saveData;
    public void NewGameMenuLogic(GameObject newGameUI)
    {
        if(!LemonStudiosCsExtensions.DoesFileExist(Path.Combine(Application.persistentDataPath, "missionMonkeyData.json")))
        {
            saveData.GenerateSaveData();
            saveData.LoadSaveData();
        }
        else
        {
            newGameUI.SetActive(true);
        }
    }
}
