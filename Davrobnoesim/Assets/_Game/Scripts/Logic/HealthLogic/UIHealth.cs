using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private PlayerHealth playerHealth = null;

    private void Awake()
    {
        TryGetComponent<Slider>(out slider);
    }

    private void Reset()
    {
        if (!playerHealth)
            playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnEnable()
    {
        UpdateGoldUI(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        playerHealth.OnHealthChanged += HandleHealthChange;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= HandleHealthChange;
    }

    private void HandleHealthChange(object sender, PlayerHealth.HealthChangedArgs args)
    {
        UpdateGoldUI(args.CurrentHealth, args.MaxHealth);
    }

    private void UpdateGoldUI(int currentHealth, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
}
