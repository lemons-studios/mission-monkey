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
        lastSaveDateText.text = GetSaveDataInfoFromTag<string>("lastSaveDate");
    }

    private string FormatSavedSceneNames()
    {
        return GetSaveDataInfoFromTag<int>("savedSceneBuildNumber") switch
        {
            0 => "Main Menu (how)",
            1 => "Chapter 1",
            2 => "Chapter 1: Interlude",
            3 => "Chapter 2",
            _ => string.Empty
        };
    }
}
