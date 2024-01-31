using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class GetSaveDataInfo : MonoBehaviour
{
    public SaveData saveData;
    private string filePath;

    private void Start()
    {
        filePath = Path.Join(Application.persistentDataPath, saveData.GetFileName());
    }

    public string GetSaveDataAsString(string tagName)
    {
        if(isSaveDataPresent(filePath))
        {
            if(IsTagInSaveData(tagName))
            {
                string data = File.ReadAllText(filePath);
                var jsonObject = JObject.Parse(data);
                return jsonObject.SelectToken(tagName).Value<string>();
            }
            else return "tagNotFoundError";
        }
        else return "fileNotFoundError";
    }

    public int GetSaveDataAsInt(string tagName)
    {
        if(isSaveDataPresent(filePath))
        {
            if(IsTagInSaveData(tagName))
            {
                string data = File.ReadAllText(filePath);
                var jsonObject = JObject.Parse(data);
                return jsonObject.SelectToken(tagName).Value<int>();
            }
        }

        return 1;
    }

    public string GetSavedSceneName()
    {
        if(isSaveDataPresent(filePath))
        {
            int buildNumber = GetSaveDataAsInt("currentSceneBuildNumber");
            switch(buildNumber)
            {
                // More cases will be added as more and more story elements get added in. 
                // There is 100% a better way to do this but 1am me can't think of a better way
                case 0:
                    return "Main Menu";
                case 1:
                    return "Chapter 1";
                case 2:
                    return "Chapter 1: Epilogue";
                case 3:
                    return "Chapter 2";
            }

            return null;
        }
        else return "unknownSceneError";
    }

    private bool IsTagInSaveData(string tagName)
    {
        if(isSaveDataPresent(filePath))
        {
            string data = File.ReadAllText(Path.Join(Application.persistentDataPath, saveData.GetFileName()));
            if(data.Contains(tagName))
            {
                // Debug.Log("File contains tag '" + tagName + "'");
                return true;
            }
            else 
            {
                Debug.LogError("Tag '" + tagName + "' not found in " + data);
                return false;
            }
        }
        else return false;
    }

    public bool isSaveDataPresent(string filePath)
    {
        if(File.Exists(filePath))
        {
            return true;
        }
        else return false;
    }
    public string GetSaveDirectory()
    {
        return filePath;
    }
}
