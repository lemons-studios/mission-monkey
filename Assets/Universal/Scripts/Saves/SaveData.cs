using Discord;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    JsonData jsonData = new JsonData();

    private GameObject Player;
    private CharacterController playerController;

    private string currentActiveScene;
    private string persistentData;
    private string fileName = "missionMonkeyData.json";
    private string fileDir;

    private static bool isSceneLoadedFromSaveData = false;

    // Encryption/Decryption key
    private readonly string decryptionKey = "@_MbFO6g;Zg=4P@f5;tpdViNJ9j_}~xQa96')VOwC4SFhp6E#I"; // Literally don't care if you use this to decrypt the save file, go right ahead lmao

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
        // Resume game in the case that the game is loaded from the game pause menu
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }


        currentActiveScene = SceneManager.GetActiveScene().name;
        persistentData = Application.persistentDataPath; // Read up on the Unity docs on what the persistent data path is on different operating systems
        fileDir = Path.Combine(persistentData, fileName); 
        // Debug.Log(fileDir);

        // Player does not exist in the MainMenu scene, only look for it outside of that scene to prevent an error
        if (currentActiveScene != "MainMenu")
        {
            Player = GameObject.FindWithTag("Player");
            playerController = Player.GetComponent<CharacterController>();
        }

        // Generate save data if the file could not be found in the proper location
        if (!doesSaveDataExist())
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
        if (File.Exists(fileDir))
        {
            File.Delete(fileDir);
        }

        string defaultData = jsonData.JsonDataToString(currentActiveScene, new Vector3(-85, 0.5f, -11.75f)); // The coordinates are the default position the player spawns in in the first game scene
        File.WriteAllText(fileDir, defaultData);
        /// File.WriteAllText(fileDir, EncryptSaveData(defaultData)); // For Later
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

    private string EncryptSaveData(string inputData)
    {
        if (File.Exists(fileDir))
        {
            string output = "";
            for(int i = 0; i < inputData.Length; i++)
            {
                output += (char)(inputData[i] ^ decryptionKey[i % decryptionKey.Length]);
            }
            return output;
        }
        else
        {
            return File.ReadAllText(fileDir);
        }
        
    }

    private string DecryptSaveData()
    {
        return ""; // Temporary value
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