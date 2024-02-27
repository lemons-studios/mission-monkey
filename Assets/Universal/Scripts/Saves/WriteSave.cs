using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WriteSave : SaveDataBase
{
    private SaveDataTemplate saveDataTemplate;
    private void Start()
    {
        saveDataTemplate = new SaveDataTemplate();
        if (!DoesSaveDataFileExist())
        {
            Debug.Log("First Load Detected. Generating Save Data.....");
            GenerateSaveData();
        }
    }

    // This method only runs if no save data is detected or if the save data was just deleted
    private void GenerateSaveData()
    {
        File.WriteAllText(GetSavePath(), saveDataTemplate.CreateSaveJsonData("Chapter1", 1, 100, new Vector3(-105f, 3f, -45f), true));
    }

    public void WriteSaveData()
    {
        // WriteSaveData() can only run in game scenes, which mean that they should contain all the scripts that are about to be called, as
        // all the scripts are attached to the player model
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 currentPlayerPosition = player.transform.position;
        int currentPlayerHealth = player.GetComponent<PlayerHealth>().GetHealth();
        string currentScene = SceneManager.GetActiveScene().name;
        int curretnSceneBuildNumber = SceneManager.GetActiveScene().buildIndex;

        string saveContents = saveDataTemplate.CreateSaveJsonData(currentScene, curretnSceneBuildNumber, currentPlayerHealth, currentPlayerPosition, false);
        File.WriteAllText(GetSavePath(), saveContents);
    }

    // Delete the save data file and regenerate the file (As it is needed)
    public void DeleteSaveData()
    {
        // Would involve regenerating the save after
        File.Delete(GetSavePath());
        GenerateSaveData();
    }
}

internal class SaveDataTemplate
{
    public Vector3 playerPosition;
    public string savedSceneName;
    public string lastSaveDate;
    public string lastPlayedVersion;
    public int remainingHealth;
    public int savedSceneBuildNumber;
    public bool isNewGame;

    public string CreateSaveJsonData(string currentScene, int currentSceneIndex, int playerHealth, Vector3 currentPlayerPos, bool isNewlyGeneratedSave)
    {
        playerPosition = currentPlayerPos;
        savedSceneName = currentScene;
        lastSaveDate = GetFormattedCurrentTime();
        remainingHealth = playerHealth;
        lastPlayedVersion = Application.version;
        isNewGame = isNewlyGeneratedSave;
        savedSceneBuildNumber = currentSceneIndex;

        return JsonUtility.ToJson(this);
    }

    // ReSharper disable twice MemberCanBePrivate.Global
    public string GetFormattedCurrentTime()
    {
        DateTime unformattedSaveTime = DateTime.Now;
        // Convert current system time to date formatting in the System locale (In my case, En_CA)
        string pattern = GetCultureTimePattern(CultureInfo.CurrentCulture);
        string formattedTime = unformattedSaveTime.ToString(pattern);
        return formattedTime;
    }

    public string GetCultureTimePattern(CultureInfo culture)
    {
        // Should return something along the lines of "dd/MM/yyyy, hh:mm tt" (This depends on what the current System Locale is)
        return culture.DateTimeFormat.ShortDatePattern + ", " + culture.DateTimeFormat.LongTimePattern;
    }
}
