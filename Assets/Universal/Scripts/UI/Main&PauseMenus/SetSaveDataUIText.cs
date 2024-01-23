using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetSaveDataUIText : MonoBehaviour
{
    public GetSaveDataInfo getSaveDataInfo;
    public TextMeshProUGUI chapterNameText, lastSaveDateText;
    public Image chapterPreview;
    
    private void Start() 
    {
        chapterNameText.text = getSaveDataInfo.GetSavedSceneName();
        lastSaveDateText.text = getSaveDataInfo.GetSaveDataAsString("lastSaveDate");
    }
}
