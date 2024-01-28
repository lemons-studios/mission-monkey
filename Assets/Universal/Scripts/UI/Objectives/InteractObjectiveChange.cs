public class InteractObjectiveChange : Interactable
{
    public string newObjective;
    private ChangeObjective changeObjective;

    private void Start()
    {
        changeObjective = new ChangeObjective();
    }

    protected override void Interact()
    {
        base.Interact();
        changeObjective.ChangeObjectiveText(newObjective);
    }
}
