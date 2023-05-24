using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public GameObject HealthBar;
    public TextMeshProUGUI HealthText;
    private float TransitionTime = 0.5f;
    private Color fullHealthColour = new Color(94, 185, 93);
    private Color HalfHealthColor = new Color(195, 173, 47);
    private Color LowHealthColor = new Color(241, 101, 61);

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

        HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(-369f + PlayerHealth.Health * 3.69f, 0f);
    }
}