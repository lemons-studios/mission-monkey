using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public string saveFile;
    private string saveName = "missionMonkeyData.json";
    public static Vector3 playerLoadPos; // Will keep null unless there is a value to be loaded

    private bool isEditor()
    {
        // Checks the runtime environment of the script
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            return true;
        }
        else return false;
    }

    public SaveData()
    {
        // Application.persistentDataPath is supported on all platforms Mission Monkey targets
        // By the way, switch cases are awesome
        switch (isEditor())
        {
            case true:
                saveFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, saveName);
                break;
            case false:
                saveFile = Path.Combine(Application.persistentDataPath, saveName);
                break;
        }

        if (!File.Exists(saveFile))
        {
            generateSaveData(saveFile);
        }
    }

    public void generateSaveData(string saveDir)
    {
        // The Newtonsoft Docs said I should do it like this so I did
        SaveDataFile saveDataFile = new SaveDataFile
        {
            savedScene = 0,
            savedPosition = new Vector3() // Generate Empty
        };
        string jsonData = JsonConvert.SerializeObject(saveDataFile, Formatting.Indented); // Convert all of the data in the saveDataFile instatiated class to a valid JSON file
        File.WriteAllText(jsonData, saveDir); // Write the converted JSON to the save directory specified by whatever is calling the method 
    }

    public void loadSaveData()
    {
        string jsonDataToText = File.ReadAllText(saveFile);
        SaveDataFile saveDataFile = JsonConvert.DeserializeObject<SaveDataFile>(jsonDataToText);

        playerLoadPos = saveDataFile.savedPosition;
        SceneManager.LoadScene(saveDataFile.savedScene);
    }

    public void deleteSaveData()
    {
        // Add any extra settings keys here when they are added (This should be a list sometimes in the future)
        float tempVolHolder = PlayerPrefs.GetFloat("Volume");
        float tempFovHolder = PlayerPrefs.GetFloat("Fov");
        float tempMsHolder = PlayerPrefs.GetFloat("MouseSensitivityValue");
        int tempAntiAliasingHolder = PlayerPrefs.GetInt("AntiAliasing");
        int tempQualityHolder = PlayerPrefs.GetInt("QualityLevel");

        File.Delete(saveFile);
        PlayerPrefs.DeleteAll();

        // Regenerate save data JSON after wiping
        if (isEditor())
        {
            generateSaveData(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, saveName));
        }
        else
        {
            generateSaveData(saveFile);
        }
        resetSettingsKeyValues(tempVolHolder, tempFovHolder, tempMsHolder, tempAntiAliasingHolder, tempQualityHolder);
    }

    private void resetSettingsKeyValues(float Volume, float Fov, float mouseSens, int antiAliasing, int qualityPreset)
    {
        PlayerPrefs.SetFloat("Volume", Volume);
        PlayerPrefs.SetFloat("MouseSensitivityValue", mouseSens);
        PlayerPrefs.SetFloat("Fov", Fov);
        PlayerPrefs.SetInt("QualityLevel", qualityPreset);
        PlayerPrefs.SetInt("AntiAliasing", antiAliasing);
    }
}


class SaveDataFile
{
    // More will probably be added here in the future
    public int savedScene { get; set; }
    public Vector3 savedPosition { get; set; }
}