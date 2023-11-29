using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class SaveData : MonoBehaviour
{
    JsonData jsonData = new JsonData();
    public GameObject Player;

    private string currentActiveScene;
    private string persistentData;
    private string fileName = "missionMonkeyData.json";
    private string fileDir;

    private void Start()
    {
        currentActiveScene = SceneManager.GetActiveScene().name;
        persistentData = Application.persistentDataPath;
        fileDir = Path.Combine(persistentData, fileName);

        if (!File.Exists(fileDir))
        {
            generateSaveData();
        }
    }

    public void generateSaveData()
    {
        string jsonDataToWrite = jsonData.jsonDataToString(currentActiveScene, new Vector3(-85, 0.5f, -11.75f));
        File.WriteAllText(fileDir, jsonDataToWrite);
    }

    public void loadSaveData()
    {

    }

    public void deleteSaveData()
    {
        // Add any extra settings keys here when they are added (These will probably be replaced with a json file too later)
        float tempVolHolder = PlayerPrefs.GetFloat("Volume");
        float tempFovHolder = PlayerPrefs.GetFloat("Fov");
        float tempMsHolder = PlayerPrefs.GetFloat("MouseSensitivityValue");
        int tempAntiAliasingHolder = PlayerPrefs.GetInt("AntiAliasing");
        int tempQualityHolder = PlayerPrefs.GetInt("QualityLevel");

        PlayerPrefs.DeleteAll();

        // Regenerate save data JSON after wiping
        generateSaveData();


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

[Serializable]
class JsonData
{
    public string currentScene;
    public Vector3 playerPosition;

    public string jsonDataToString(string scene, Vector3 position)
    {
        currentScene = scene;
        playerPosition = position;

        return JsonUtility.ToJson(this);
    }
}