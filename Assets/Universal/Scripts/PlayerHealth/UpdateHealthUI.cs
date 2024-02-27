using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthUI : MonoBehaviour
{
    public GameObject healthUI;
    public TextMeshProUGUI healthText;
    public float healthBarLerpSpeed = 10;
    private Image playerHealthImage;
    private Color highHealthColour, midHealthColour, lowHealthColour;

    private void Start()
    {
        // I might want to make these values be more flexible in the future, them being hardcoded is fine for now
        highHealthColour = new Color(0.2863f, 0.8196f, 0.4235f);
        midHealthColour = new Color(0.9451f, 0.7608f, 0.2196f);
        lowHealthColour = new Color(0.7921f, 0.0862f, 0.1333f);

        playerHealthImage = healthUI.GetComponent<Image>();
    }

    public void Update()
    {
        int currentPlayerHealth = GetComponent<PlayerHealth>().GetHealth();

        if (currentPlayerHealth >= 65)
        {
            playerHealthImage.color = highHealthColour;
        }

        if (currentPlayerHealth is >= 35 and <= 64)
        {
            playerHealthImage.color = midHealthColour;
        }

        if (currentPlayerHealth is >= 0 and <= 34)
        {
            playerHealthImage.color = lowHealthColour;
        }

        healthText.text = currentPlayerHealth.ToString() + "/100";

        float currentFillAmount = playerHealthImage.fillAmount;
        float fillAmount = Mathf.Lerp(currentFillAmount, currentPlayerHealth / 100f, Time.deltaTime * healthBarLerpSpeed); // Wtf is a lerp I gotta learn this
        playerHealthImage.fillAmount = fillAmount;
    }
}
