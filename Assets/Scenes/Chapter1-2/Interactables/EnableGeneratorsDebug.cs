public class EnableGeneratorsDebug : Interactable
{
    // Start is called before the first frame update
    void Start()
    {

    }
    protected override void Interact()
    {
        TurnOnGenerators.AreGeneratorsOn = true;
    }
}
