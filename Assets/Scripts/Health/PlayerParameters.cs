using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerParameters : MonoBehaviour, IParameters
{
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        healthBar = healthBar.GetComponent<Image>();
    }
     
    public void HealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
