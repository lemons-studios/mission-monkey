using TMPro;
using UnityEngine.UI;

public class SetSaveDataUIText : SaveDataBase
{
    public TextMeshProUGUI chapterNameText, lastSaveDateText;
    public Image chapterPreview;

    // Should make this consume less resources at some point in the future, but it SHOULD work whenever the player saves again    
    private void Update()
    {
        chapterNameText.text = FormatSavedSceneNames();
        lastSaveDateText.text = base.GetSaveDataInfoFromTag<string>("lastSaveDate");
    }

    private string FormatSavedSceneNames()
    {
        switch (base.GetSaveDataInfoFromTag<int>("savedSceneBuildNumber"))
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
