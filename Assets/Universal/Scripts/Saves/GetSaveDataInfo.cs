using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class GetSaveDataInfo : MonoBehaviour
{
    public SaveData saveData;

    public string GetSaveInfoFromTag(string tagName)
    {
        string jsonData = File.ReadAllText(Path.Join(Application.persistentDataPath, saveData.GetFileName()));
        if(jsonData.Contains(tagName))
        {
            try
            {
                Debug.Log("Holy moly it was found");
                var jsonObject = JObject.Parse(jsonData);
                return jsonObject.SelectToken(tagName).Value<string>();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

        }
        else Debug.LogError("tag not found");
        return null;
    }

    public string GetSavedSceneName()
    {
        int buildNumber = Int32.Parse(GetSaveInfoFromTag("currentSceneBuildNumber"));
        if(buildNumber > 0)
        {
            switch(buildNumber)
            {
                // More cases will be added as more and more story elements get added in. 
                // There is 100% a better way to do this but 1am me can't think of a better way
                case 1:
                    return "Chapter 1";
                case 2:
                    return "Chapter 1: Interlude";
                case 3:
                    return "Chapter 2";
            }
        }
        return null;
    }
}
