using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthUI : MonoBehaviour
{
    public GameObject healthUI;
    public TextMeshProUGUI healthText;

    private PlayerHealth playerHealth;
    private Color highHealthColour, midHealthColour, lowHealthColour;

    private void Start()
    {
        // I might want to make these values be more flexible in the future, them being hardcoded is fine for now
        highHealthColour = new Color(0.2863f, 0.8196f, 0.4235f);
        midHealthColour = new Color(0.9451f, 0.7608f, 0.2196f);
        lowHealthColour = new Color(0.7921f, 0.0862f, 0.1333f);

        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        int currentPlayerHealth = playerHealth.GetHealth();
        Image playerHealthImage = healthUI.GetComponent<Image>();

        if (currentPlayerHealth >= 65)
        {
            playerHealthImage.color = highHealthColour;
        }

        if (currentPlayerHealth >= 35 && currentPlayerHealth <= 64)
        {
            playerHealthImage.color = midHealthColour;
        }

        if (currentPlayerHealth >= 0 && currentPlayerHealth <= 34)
        {
            playerHealthImage.color = lowHealthColour;
        }

        playerHealthImage.fillAmount = currentPlayerHealth / 100;
        healthText.text = currentPlayerHealth.ToString() + "/100";
    }
}
