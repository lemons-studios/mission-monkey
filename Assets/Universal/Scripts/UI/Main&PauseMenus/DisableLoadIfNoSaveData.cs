using UnityEngine;
using UnityEngine.UI;

public class DisableLoadIfNoSaveData : MonoBehaviour
{
    public GetSaveDataInfo getSaveDataInfo;
    public Button loadGameButton;

    private void Start() 
    {
        if(!getSaveDataInfo.isSaveDataPresent(getSaveDataInfo.GetSaveDirectory()))    
        {
            loadGameButton.interactable = false;
        }
    }

    public void EnableLoadButton()
    {
        loadGameButton.interactable = true;
    }
}
