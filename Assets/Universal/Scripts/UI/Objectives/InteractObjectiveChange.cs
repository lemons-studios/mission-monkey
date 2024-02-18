using TMPro;
using UnityEngine;

public class InteractObjectiveChange : Interactable
{
    public string newObjective;
    private TextMeshProUGUI objectiveText;
    

    private void Start()
    {
        objectiveText = GameObject.FindGameObjectWithTag("ObjectiveUI").GetComponent<TextMeshProUGUI>();
    }

    protected override void Interact()
    {
        base.Interact();
        objectiveText.text = newObjective;
    }

    private void OnDestroy() 
    {
        objectiveText = null;
    }
}
