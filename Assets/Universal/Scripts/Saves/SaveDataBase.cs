using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveDataBase : MonoBehaviour
{
    private string filePath;
    public static bool isLastLoadFromSaveData;
    
    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "MissionMonkeyGlobalData.json");
    }

    public JObject ParseSaveDataFile()
    {
        return JObject.Parse(File.ReadAllText(filePath));
    }

    public string ReadSaveDataFile()
    {
        return File.ReadAllText(filePath);
    }


    public T GetSaveDataInfoFromTag<T>(string tagName)
    {
        if (IsTagInSaveData(tagName))
        {
            JObject saveData = ParseSaveDataFile();
            // Select the json token from the save file
            JToken token = saveData.SelectToken(tagName);
            if (token != null && token.Type != JTokenType.Null)
            {
                return token.Value<T>();
            }
        }
        return default;  // "default" is the default value of whatever Type was specified in the method call
    }

    // Specifically for position. May not be needed now, but may be needed in the future.
    public Vector3 GetPositionFromSaveData()
    {
        if (IsTagInSaveData("playerPosition"))
        {
            JObject saveData = ParseSaveDataFile();
            // Get Coordinates of tag playerPosition
            float savePosX = saveData.SelectToken("playerPosition.x").Value<float>();
            float savePosY = saveData.SelectToken("playerPosition.y").Value<float>();
            float savePosZ = saveData.SelectToken("playerPosition.z").Value<float>();
            return new Vector3(savePosX, savePosY, savePosZ);
        }
        else return Vector3.zero;   // I should probably have better errors in here in the future
    }

    private bool IsTagInSaveData(string tagName)
    {
        if (DoesSaveDataFileExist())
        {
            string data = ReadSaveDataFile();
            if (data.Contains(tagName))
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

    public bool DoesSaveDataFileExist()
    {
        if (File.Exists(GetSavePath()))
        {
            return true;
        }
        else return false;
    }

    public string GetSavePath()
    {
        return filePath;
    }
}
