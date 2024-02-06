using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSave : SaveDataBase
{
    public void LoadSaveData()
    {
        StartCoroutine(LoadSaveCoroutine());
    }

    // AI is very good when used effectively
    public IEnumerator LoadSaveCoroutine()
    {
        int lastSavedSceneBuildIndex = base.GetSaveDataInfoFromTag<int>("savedSceneBuildNumber");
        int currentlyLoadedScene = SceneManager.GetActiveScene().buildIndex;
    
        // Start the asynchronous unloading of the current scene
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(currentlyLoadedScene);
    
        // Wait for the unloading to complete
        yield return unloadOperation;
    
        // Destroy the specific GameObject before loading the new scene
        GameObject playerAssets = GameObject.FindGameObjectWithTag("PlayerAssets");
        if (playerAssets != null && playerAssets.scene.buildIndex == currentlyLoadedScene)
        {
            Destroy(playerAssets);
        }
    
        // Load the saved scene additively
        SceneManager.LoadScene(lastSavedSceneBuildIndex, LoadSceneMode.Additive);
    }
}
