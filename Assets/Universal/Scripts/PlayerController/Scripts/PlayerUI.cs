using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private bool canUpdatePromptText = true;
    private bool fadeIn = false;
    private bool fadeOut = true;

    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private CanvasGroup promptTextContainer;

    public void UpdateText(string promptMessage)
    {
        if (promptMessage == "")
        {
            canUpdatePromptText = false;
            fadeIn = false;
            fadeOut = true;
        }
        else
        {
            canUpdatePromptText = true;
            fadeIn = true;
            fadeOut = false;
        }
        if (canUpdatePromptText)
        {
            promptText.text = promptMessage;
        }
    }

    void Update()
    {
        if (fadeIn)
        {
            if (promptTextContainer.alpha < 1)
            {
                promptTextContainer.alpha += Time.deltaTime * 4;
                canUpdatePromptText = true;
            }
        }
        else if (fadeOut)
        {
            if (promptTextContainer.alpha > 0)
            {
                promptTextContainer.alpha -= Time.deltaTime * 4;
                canUpdatePromptText = false;
            }
            else
            {
                canUpdatePromptText = true;
            }
        }
    }
}
