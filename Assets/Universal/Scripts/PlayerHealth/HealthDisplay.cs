using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public GameObject HealthBar;
    public TextMeshProUGUI HealthText;
    // private float TransitionTime = 0.5f;
    private Color fullHealthColour = new Color(0.37f, 0.73f, 0.36f);
    private Color HalfHealthColor = new Color(0.74f, 0.68f, 0.18f);
    private Color LowHealthColor = new Color(0.95f, 0.40f, 0.24f);

    private float targetOffset;
    private float xOffset;

    void Update()
    {
        HealthText.text = PlayerHealth.Health.ToString();
        if (PlayerHealth.Health >= 65f)
        {
            HealthBar.GetComponent<Image>().color = fullHealthColour;
        }
        if (PlayerHealth.Health >= 31f && PlayerHealth.Health <= 64f)
        {
            HealthBar.GetComponent<Image>().color = HalfHealthColor;
        }
        if (PlayerHealth.Health >= 1f && PlayerHealth.Health <= 30f)
        {
            HealthBar.GetComponent<Image>().color = LowHealthColor;
        }

        targetOffset = -369f + PlayerHealth.Health * 3.69f;
        xOffset = HealthBar.GetComponent<RectTransform>().offsetMax.x;

        if (xOffset < targetOffset)
        {
            if (targetOffset - xOffset < 10)
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(targetOffset, 0f);
            }
            else
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(xOffset + 10, 0f);
            }
        }
        else if (xOffset > targetOffset)
        {
            if (xOffset - targetOffset < 10)
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(targetOffset, 0f);
            }
            else
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(xOffset - 10, 0f);
            }
        }
        // HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(-369f + PlayerHealth.Health * 3.69f, 0f);
    }
}