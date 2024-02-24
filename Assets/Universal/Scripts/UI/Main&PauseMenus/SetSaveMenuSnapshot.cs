using UnityEngine.UI;
using UnityEngine;

public class SetSaveMenuSnapshot : SaveDataBase
{
    public Sprite[] chapterSnapshots;
    public Image saveMenuSnapshot;

    private void OnEnable()
    {
        // currentSavedChapter returns the scene build number found in missionMonkeyData.json. It then selects a snapshot from the chapterSnapshots array  
        int currentSavedChapter = base.GetSaveDataInfoFromTag<int>("savedSceneBuildNumber");
        saveMenuSnapshot.sprite = chapterSnapshots[currentSavedChapter]; // Scene build numbers also start at 0, like arrays, so no + 1 is needed
    }
}
