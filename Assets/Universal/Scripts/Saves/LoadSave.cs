using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSave : SaveDataBase
{
    public void LoadSaveData()
    {
        int lastSavedSceneBuildIndex = base.GetSaveDataInfoFromTag<int>("savedSceneBuildNumber");

        // Load the saved scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(lastSavedSceneBuildIndex, LoadSceneMode.Single);
        SaveDataBase.IsLastLoadFromSaveData = true;
    }
}
