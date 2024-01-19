using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class GetSaveDataInfo : MonoBehaviour
{
    public SaveData saveData;
    private string jsonData;


    private void A()
    {
        jsonData = File.ReadAllText(Path.Join(Application.persistentDataPath, saveData.GetFileName()));
    }

    public string GetSaveInfoAsString(string tagName)
    {
        if(jsonData.Contains(tagName))
        {
            if(IsTagInSaveData(tagName))
            {
                try
                {
                    var jsonObject = JObject.Parse(jsonData);
                    return jsonObject.SelectToken(tagName).Value<string>();
                }
                catch (Exception e) 
                {
                    Debug.LogError(e);
                }
            }

        }
        return "tagNotFoundError";
    }

    public int GetSaveInfoAsInt(string tagName)
    {
        if(IsTagInSaveData(tagName))
        {
            try
            {
                var jsonObject = JObject.Parse(jsonData);
                return jsonObject.SelectToken(tagName).Value<int>();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
                
        }
        return 1;
    }

    public string GetSavedSceneName()
    {
        int buildNumber = GetSaveInfoAsInt("currentSceneBuildNumber");
        if(buildNumber > 0)
        {
            switch(buildNumber)
            {
                // More cases will be added as more and more story elements get added in. 
                // There is 100% a better way to do this but 1am me can't think of a better way
                case 0:
                    return "Main Menu?? How tf";
                case 1:
                    return "Chapter 1";
                case 2:
                    return "Chapter 1: Epilogue";
                case 3:
                    return "Chapter 2";
            }
        }
        return null;
    }

    private bool IsTagInSaveData(string tagName)
    {
        if(jsonData.Contains(tagName))
        {
            // Debug.Log("File contains tag '" + tagName + "'");
            return true;
        }
        else 
        {
            Debug.LogError("Tag '" + tagName + "' not found in " + jsonData);
            return false;
        }
    }
}
