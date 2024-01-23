using TMPro;
using UnityEngine;

public class ChangeObjective
{
    private TextMeshProUGUI objectiveText;
    private GameObject objectiveUI;

    private void Start()
    {
        objectiveUI = GameObject.FindGameObjectWithTag("ObjectiveUI");
        objectiveText = objectiveUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ChangeObjectiveText(string newObjective)
    {
        objectiveText.text = newObjective;
    }

    public void toggleObjective(bool showObjective)
    {
        objectiveUI.SetActive(showObjective);
    }
}
