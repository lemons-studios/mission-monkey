using LemonStudios.CsExtensions;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    private JsonData jsonData = new JsonData();

    private GameObject Player;
    private CharacterController playerController;

    private string currentActiveScene;
    private string persistentData;
    private string fileName = "missionMonkeyData.json";
    private string fileDir;
    private static bool isSceneLoadedFromSaveData = false;

    // Encryption/Decryption key
    

    private void Start()
    {
        currentActiveScene = SceneManager.GetActiveScene().name;
        persistentData = Application.persistentDataPath; // Read up on the Unity docs on what the persistent data path is on different operating systems
        fileDir = Path.Combine(persistentData, fileName);

        // Resume game in the case that the game is loaded from the game pause menu
        Time.timeScale = 1;


        // Player does not exist in the MainMenu scene, only look for it outside of that scene to prevent an error
        if (currentActiveScene != "MainMenu")
        {
            Player = GameObject.FindWithTag("Player");
            playerController = Player.GetComponent<CharacterController>();
        }

        // Generate save data if the file could not be found in the proper location
        if (!LemonStudiosCsExtensions.DoesFileExist(fileDir))
        {
            GenerateSaveData();
        }

        if (currentActiveScene != "MainMenu" && isSceneLoadedFromSaveData)
        {
            // The player controller must be disabled before the script is able to move the player model anywhere
            playerController.enabled = false;
            string jsonData = File.ReadAllText(fileDir);
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

    public void GenerateSaveData()
    {
        // New game = delete save file and regenerate
        if (LemonStudiosCsExtensions.DoesFileExist(fileDir))
        {
            File.Delete(fileDir);
        }
        string defaultData = jsonData.JsonDataToString(currentActiveScene, new Vector3(-0f, 0f, -0f)); // Placeholder coordinates
        File.WriteAllText(fileDir, defaultData);
    }

    public void LoadSaveData()
    {
        string jsonData = File.ReadAllText(fileDir);
        var jsonObject = JObject.Parse(jsonData);
        var savedLoadedScene = jsonObject.Value<string>("currentScene");
        // Debug.Log(savedLoadedScene);

        SceneManager.LoadScene(savedLoadedScene);
        isSceneLoadedFromSaveData = true;
    }

    public void WriteSaveData()
    {
        File.Delete(fileDir);
        string updatedData = jsonData.JsonDataToString(currentActiveScene, Player.transform.position);
        File.WriteAllText(fileDir, updatedData);
    }

    public void DeleteSaveData()
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
        GenerateSaveData();

        ResetSettingsKeyValues(tempVolHolder, tempFovHolder, tempMsHolder, tempAntiAliasingHolder, tempQualityHolder);
    }

    private void ResetSettingsKeyValues(float Volume, float Fov, float mouseSens, int antiAliasing, int qualityPreset)
    {
        PlayerPrefs.SetFloat("Volume", Volume);
        PlayerPrefs.SetFloat("MouseSensitivityValue", mouseSens);
        PlayerPrefs.SetFloat("Fov", Fov);
        PlayerPrefs.SetInt("QualityLevel", qualityPreset);
        PlayerPrefs.SetInt("AntiAliasing", antiAliasing);
    }
    public string GetSaveDataLocation()
    {
        return fileDir;
    }
}

[Serializable]
class JsonData
{
    public string currentScene;
    public Vector3 playerPosition;

    public string JsonDataToString(string scene, Vector3 position)
    {
        currentScene = scene;
        playerPosition = position;

        return JsonUtility.ToJson(this);
    }
}