using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private PlayerHealth playerHealth = null;

    private void Awake()
    {
        TryGetComponent<TextMeshProUGUI>(out text);
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
        text.text = $"{Mathf.Ceil(currentHealth)}/{Mathf.Ceil(maxHealth)}";
    }
}
