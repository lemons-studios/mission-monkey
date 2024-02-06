using UnityEngine;

public class DetectNewVersion : SaveDataBase
{
    public GameObject newVersionUI;
    private void Start() 
    {
        if(base.GetSaveDataInfoFromTag<string>("lastPlayedVersion") != Application.version || !base.DoesSaveDataFileExist())
        {
            newVersionUI.SetActive(true);
        }    
        else return;
    }
}
