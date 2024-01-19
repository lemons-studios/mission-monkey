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
    public string fileName = "missionMonkeyData.json";
    private string filePath;
    private static bool isSceneLoadedFromSaveData = false;

    // Uses Awake() instead of Start() so any script using this script can actually use it without errors
    private void Awake()
    {
        currentActiveScene = SceneManager.GetActiveScene().name;
        persistentData = Application.persistentDataPath; // Read up on the Unity docs on what the persistent data path is on different operating systems
        filePath = Path.Combine(persistentData, fileName);
        // Resume game in the case that the game is loaded from the game pause menu
        Time.timeScale = 1;


        // Player does not exist in the MainMenu scene, only look for it outside of that scene to prevent an error
        if (currentActiveScene != "MainMenu")
        {
            Player = GameObject.FindWithTag("Player");
            playerController = Player.GetComponent<CharacterController>();
            if(!LemonStudiosCsExtensions.DoesFileExist(filePath))
            {
                GenerateSaveData();
            }
        }

        if (currentActiveScene != "MainMenu" && isSceneLoadedFromSaveData)
        {
            // The player controller must be disabled before the script is able to move the player model anywhere
            playerController.enabled = false;
            string jsonData = File.ReadAllText(filePath);
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
        string defaultData = jsonData.JsonDataToString("Chapter1", new Vector3(-128.1f, 36.2f, -46.8f)); // Current Coordinates for the starting pos in the debug ch1 scene
        File.WriteAllText(filePath, defaultData);
    }

    public void LoadSaveData()
    {
        string jsonData = File.ReadAllText(filePath);
        var jsonObject = JObject.Parse(jsonData);
        var savedLoadedScene = jsonObject.Value<string>("currentScene");

        SceneManager.LoadScene(savedLoadedScene);
        isSceneLoadedFromSaveData = true;
    }

    public void WriteSaveData()
    {
        File.Delete(filePath);
        string updatedData = jsonData.JsonDataToString(currentActiveScene, Player.transform.position);
        File.WriteAllText(filePath, updatedData);
    }

    public void RegenerateSaveData()
    {
        DeleteSaveData();
        GenerateSaveData();
    }
    private void DeleteSaveData()
    {
        File.Delete(filePath);
    }

    public string GetSaveDirectory()
    {
        // Returns the directory the save data JSON is stored in
        return filePath;
    }

    public string GetFileName()
    {
        // Returns the name of the player's savedata
        return fileName;
    }
}

[Serializable]
class JsonData
{
    // Note to future self: ANY VARS FOR SAVE DATA NEED TO BE PUBLIC, OR IT WON'T BE RETURNED IN JsonDataToString()
    public string currentScene;
    public int currentSceneBuildNumber;
    public Vector3 playerPosition;
    public string lastSaveDate;
    public string lastPlayedVersion;

    public string JsonDataToString(string scene, Vector3 position)
    {
        // Get system time in yyyy-mm-dd, hh:mm:ss
        DateTime unformattedSaveTime = DateTime.Now;
        // Convert system time to dd-mm-yyyy, hh:mm
        string formattedSaveTime = unformattedSaveTime.ToString("dd/MM/yyyy, hh:mm tt");
        
        currentScene = scene;
        playerPosition = position;
        currentSceneBuildNumber = SceneManager.GetActiveScene().buildIndex;
        lastSaveDate = formattedSaveTime;
        lastPlayedVersion = Application.version;
        return JsonUtility.ToJson(this);
    }
}
