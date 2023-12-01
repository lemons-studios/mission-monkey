using Newtonsoft.Json.Linq;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    JsonData jsonData = new JsonData();

    public GameObject Player;
    private CharacterController playerController;

    private string currentActiveScene;
    private string persistentData;

    private string fileName = "missionMonkeyData.json";
    private string fileDir;


    private static bool isSceneLoadedFromSaveData = false;

    public bool doesSaveDataExist()
    {
        if (File.Exists(fileDir))
        {
            return true;
        }
        else return false;
    }

    private void Start()
    {
        playerController = Player.GetComponent<CharacterController>();


        currentActiveScene = SceneManager.GetActiveScene().name;
        persistentData = Application.persistentDataPath;
        fileDir = Path.Combine(persistentData, fileName);

        //Debug.Log(fileDir);

        if (!File.Exists(fileDir))
        {
            generateSaveData();
        }

        if (currentActiveScene != "MainMenu" && isSceneLoadedFromSaveData)
        {
            playerController.enabled = false;
            string jsonFilePath = Path.Combine(Application.persistentDataPath, "missionMonkeyData.json");
            string jsonData = File.ReadAllText(jsonFilePath);

            JObject json = JObject.Parse(jsonData);

            // Get coordinates of x, y, and z from json 
            float posX = json.SelectToken("playerPosition.x").Value<float>();
            float posY = json.SelectToken("playerPosition.y").Value<float>();
            float posZ = json.SelectToken("playerPosition.z").Value<float>();

            // Assign the values found in the save data JSON to a new Vector3
            Player.transform.position = new Vector3(posX, posY, posZ);
            playerController.enabled = true;
            isSceneLoadedFromSaveData = false;
        }
    }

    public void generateSaveData()
    {
        if (File.Exists(fileDir))
        {
            File.Delete(fileDir);
        }

        string defaultData = jsonData.jsonDataToString(currentActiveScene, new Vector3(-85, 0.5f, -11.75f));
        File.WriteAllText(fileDir, defaultData);
    }

    public void loadSaveData()
    {
        string jsonData = File.ReadAllText(fileDir);
        var jsonObject = JObject.Parse(jsonData);
        var savedLoadedScene = jsonObject.Value<string>("currentScene");
        
        Debug.Log(savedLoadedScene);

        SceneManager.LoadScene(savedLoadedScene);
        isSceneLoadedFromSaveData = true;

        if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
    }

    public void writeSaveData()
    {
        File.Delete(fileDir);
        string updatedData = jsonData.jsonDataToString(currentActiveScene, Player.transform.position);
        File.WriteAllText(fileDir, updatedData);
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
        File.Delete(fileDir);
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