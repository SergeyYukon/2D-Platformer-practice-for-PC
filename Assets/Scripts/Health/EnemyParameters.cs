using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyParameters : MonoBehaviour, IParameters
{
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject canvasHealthBar;

    private void Awake()
    {
        healthBar = healthBar.GetComponent<Image>();
    }

    public void HealthBar(float currentHealth, float maxHealth)
    {
        StopCoroutine("healthBarOnOff");
        StartCoroutine("healthBarOnOff");
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    IEnumerator healthBarOnOff()
    {
        canvasHealthBar.SetActive(true);
        yield return new WaitForSeconds(3);
        canvasHealthBar.SetActive(false);
    }
}
