using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI HealthT;
    void Update()
    {
        HealthT.text = PlayerHealth.Health.ToString();
    }
}