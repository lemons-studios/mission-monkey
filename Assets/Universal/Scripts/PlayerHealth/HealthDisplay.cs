using TMPro;
using UnityEngine;
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

    private PlayerHealth Health;

    private void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Health = Object.FindObjectOfType<PlayerHealth>();
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void Update()
    {
        // Debug.Log(Health.Health);
        HealthText.text = Health.Health.ToString();
        if (Health.Health >= 65)
        {
            HealthBar.GetComponent<Image>().color = fullHealthColour;
        }
        if (Health.Health >= 31 && Health.Health <= 64)
        {
            HealthBar.GetComponent<Image>().color = HalfHealthColor;
        }
        if (Health.Health >= 1 && Health.Health <= 30)
        {
            HealthBar.GetComponent<Image>().color = LowHealthColor;
        }

        targetOffset = -400 + Health.Health * 4;
        xOffset = HealthBar.GetComponent<RectTransform>().offsetMax.x;

        if (xOffset < targetOffset)
        {
            if (targetOffset - xOffset < 10)
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(targetOffset, 0f);
            }
            else
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(xOffset + 10, 0);
            }
        }
        else if (xOffset > targetOffset)
        {
            if (xOffset - targetOffset < 10)
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(targetOffset, 0);
            }
            else
            {
                HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(xOffset - 10, 0);
            }
        }
        // HealthBar.GetComponent<RectTransform>().offsetMax = new Vector2(-369f + PlayerHealth.Health * 3.69f, 0f);
    }
}