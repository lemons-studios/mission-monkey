using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayerUI : MonoBehaviour
{
    public GameObject promptTextContainer;
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI promptText;

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
    void Start()
    {

    }
}
