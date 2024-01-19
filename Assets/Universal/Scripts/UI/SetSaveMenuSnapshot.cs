using UnityEngine.UI;
using UnityEngine;

public class SetSaveMenuSnapshot : MonoBehaviour
{
    public Sprite[] chapterSnapshots;
    public Image saveMenuSnapshot;
    public GetSaveDataInfo getSaveDataInfo;
    private void Awake() 
    {
        saveMenuSnapshot.sprite = chapterSnapshots[getSaveDataInfo.GetSaveDataAsInt("currentSceneBuildNumber")];
    }
}
