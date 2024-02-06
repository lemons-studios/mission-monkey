using UnityEngine.SceneManagement;

public class LoadSave : SaveDataBase
{
    public void LoadSaveData()
    {
        SceneManager.LoadScene(base.GetSaveDataInfoFromTag<string>("savedSceneName"));
    }
}
