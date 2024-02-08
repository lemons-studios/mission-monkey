using UnityEngine;
using TMPro;

public class GetVersionNumber : MonoBehaviour
{
    private TextMeshProUGUI versionText;
    private void OnEnable() 
    {
        versionText = GameObject.FindGameObjectWithTag("VersionText").GetComponent<TextMeshProUGUI>();
        versionText.text = "Version " + Application.version;
    }

    private void OnDestroy() 
    {
        versionText = null;    
    }
}
