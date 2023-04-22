using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI promptText;
    public GameObject promptTextContainer;
    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        if (promptMessage == "") {
            promptTextContainer.SetActive(false);
        } else {
            promptTextContainer.SetActive(true);
        }
        promptText.text = promptMessage;
    }
}
