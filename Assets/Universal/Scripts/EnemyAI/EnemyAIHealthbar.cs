using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAIHealthbar : MonoBehaviour
{
    public Image enemyAIHealthImage;
    public TextMeshProUGUI healthValue, enemyName;
    public float healthbarUpdateSpeed = 15.5f;
    public GameObject enemyHealthbar;

    private void Update()
    {
        // Healthbar shouldn't be active if the enemy is dead
        if(enemyAIHealthImage.fillAmount <= 0.01f)
        {
            enemyHealthbar.SetActive(false);
        }
    }

    public void SetEnemyHealthbar(EnemyAIHealth enemy)
    {
        // This can only trigger if the player hasn't attacked an enemy in the 
        // current play session or if they killed the previous enemy.
        if(!enemyHealthbar.activeSelf)
        {
            enemyHealthbar.SetActive(true);
        }
        if(enemy.GetAIHealth() == 0)
        {
            enemyHealthbar.SetActive(false);
            return;
        }

        enemyName.text = enemy.GetAIName();
        healthValue.text = enemy.GetAIHealth() + "/" + enemy.GetMaxAIHealth();

        // Pretty much the same thing as the one in UpdateHealthUI
        // StartCoroutine(LerpEnemyImageFillValue(enemy.GetAIHealth() / enemy.GetMaxAIHealth(), enemy));
        StartCoroutine(LerpEnemyImageFillValue((float) enemy.GetAIHealth() / enemy.GetMaxAIHealth()));
    }

    private IEnumerator LerpEnemyImageFillValue(float targetFill)
    {
        float currentFillAmount = enemyAIHealthImage.fillAmount;
        while(Mathf.Abs(currentFillAmount - targetFill) > 0.01f)
        {
            currentFillAmount = Mathf.Lerp(currentFillAmount, targetFill, Time.deltaTime * healthbarUpdateSpeed);
            enemyAIHealthImage.fillAmount = currentFillAmount;
            yield return new WaitForEndOfFrame();
        }
    }
}
