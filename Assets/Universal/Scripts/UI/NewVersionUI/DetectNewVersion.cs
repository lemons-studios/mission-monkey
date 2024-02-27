using UnityEngine;

public class DetectNewVersion : SaveDataBase
{
    public GameObject newVersionUI;
    private void Start()
    {
        if (GetSaveDataInfoFromTag<string>("lastPlayedVersion") != Application.version || !base.DoesSaveDataFileExist())
        {
            newVersionUI.SetActive(true);
        }
    }
}
