using TMPro;
using UnityEngine;

public class SetVersionText : MonoBehaviour
{
    public TextMeshProUGUI BuildInfoText;

    private void Start()
    {
        BuildInfoText.text = "Version " + Application.version;
    }
}