using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class SetSaveDataUIText : MonoBehaviour
{
    public GetSaveDataInfo getSaveDataInfo;
    public TextMeshProUGUI chapterNameText, lastSaveDateText;
    public Image chapterPreview;
    
    private void Start() 
    {
        chapterNameText.text = getSaveDataInfo.GetSavedSceneName();
        lastSaveDateText.text = getSaveDataInfo.GetSaveInfoAsString("lastSaveDate");
    }
}
