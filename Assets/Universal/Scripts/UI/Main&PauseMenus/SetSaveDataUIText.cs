using TMPro;
using UnityEngine.UI;

public class SetSaveDataUIText : SaveDataBase
{
    public TextMeshProUGUI chapterNameText, lastSaveDateText;
    public Image chapterPreview;
    
    private void Start() 
    {
        chapterNameText.text = formatSavedSceneNames();
        lastSaveDateText.text = base.GetSaveDataInfoFromTag<string>("lastSaveDate");
    }

    private string formatSavedSceneNames()
    {
        switch(base.GetSaveDataInfoFromTag<int>("savedSceneBuildNumber"))
        {
            case 0:
                return "Main Menu (how)";
            case 1:
                return "Chapter 1";
            case 2: 
                return "Chapter 1: Interlude";
            case 3: 
                return "Chapter 2";
        }
        return string.Empty;
    }
}
