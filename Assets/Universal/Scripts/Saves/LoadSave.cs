using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSave : SaveDataBase
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadSaveData()
    {
        int lastSavedSceneBuildIndex = base.GetSaveDataInfoFromTag<int>("savedSceneBuildNumber");

        // Load the saved scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(lastSavedSceneBuildIndex, LoadSceneMode.Single);
        SaveDataBase.isLastLoadFromSaveData = true;
    }
}
