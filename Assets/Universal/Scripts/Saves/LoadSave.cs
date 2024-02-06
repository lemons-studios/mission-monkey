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
        int currentlyLoadedScene = SceneManager.GetActiveScene().buildIndex;



        if(currentlyLoadedScene != lastSavedSceneBuildIndex)
        {
            // Load the saved scene
            SceneManager.LoadScene(lastSavedSceneBuildIndex);
            Debug.Log("Loading scene: " + lastSavedSceneBuildIndex);
        }

        else
        {
            CharacterController charController = player.GetComponent<CharacterController>();
            charController.enabled = false;
            player.transform.position = base.GetPositionFromSaveData();
            player.GetComponent<PlayerHealth>().SetHealth(base.GetSaveDataInfoFromTag<int>("remainingHealth"));
            charController.enabled = true;
        }

    }
}
