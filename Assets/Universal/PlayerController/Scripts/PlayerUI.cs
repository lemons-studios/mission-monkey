using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI promptText;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage) {
        promptText.text = promptMessage;
    }
}
