using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        UpdateHealthI(playerHealth.CurrentHealth, playerHealth.MaxHealth);
        playerHealth.OnHealthChanged += HandleHealthChange;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= HandleHealthChange;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void HandleHealthChange(object sender, PlayerHealth.HealthChangedArgs args)
    {
        UpdateHealthI(args.CurrentHealth, args.MaxHealth);
    }

    private void UpdateHealthI(int currentHealth, int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateHealthI(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

}
