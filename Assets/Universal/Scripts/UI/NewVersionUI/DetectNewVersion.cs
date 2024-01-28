using UnityEngine;

public class DetectNewVersion : MonoBehaviour
{
    public GetSaveDataInfo getSaveDataInfo;
    public GameObject newVersionUI;
    private void Start() 
    {
        if(getSaveDataInfo.GetSaveDataAsString("lastPlayedVersion") != Application.version)
        {
            newVersionUI.SetActive(true);
        }    
        else return;
    }
}
