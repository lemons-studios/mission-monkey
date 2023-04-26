using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI HealthText;
    private float TransitionTime = 0.5f;
    private Color fullHealthColour = new Color(0, 255, 0);
    private Color HalfHealthColor = new Color(255, 166, 0);
    private Color LowHealthColor = new Color(231, 0, 0);

    void Update()
    {
        HealthText.text = PlayerHealth.Health.ToString();
        if (PlayerHealth.Health >= 65f)
        {
            HealthText.color = fullHealthColour;
        }
        if (PlayerHealth.Health >= 31f && PlayerHealth.Health <= 64f)
        {
            HealthText.color = HalfHealthColor;
        }
        if (PlayerHealth.Health >= 1f && PlayerHealth.Health <= 30f)
        {
            HealthText.color = LowHealthColor;
        }
    }
}