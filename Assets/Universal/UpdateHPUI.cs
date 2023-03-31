using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateHPUI : MonoBehaviour
{
    public TMP_Text hpText;
    public ShootableObject shootableObject;

    // Update is called once per frame
    void Update()
    {
        hpText.text = "" + shootableObject.currentHealth;
    }
}
