using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private int maxHealth = 1000;

    [SerializeField] private ParticleSystem partSys;

    public event EventHandler<HealthChangedArgs> OnHealthChanged;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public int CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChanged?.Invoke(this, new HealthChangedArgs
            {
                CurrentHealth = currentHealth,
                MaxHealth = maxHealth
            });
         
        }
    }

    public int MaxHealth => maxHealth;

    public class HealthChangedArgs : EventArgs
    {
        public int CurrentHealth{ get; set;}
        public int MaxHealth { get; set;}
    }

    public void ChangeHealth(int amount)
    {
        CurrentHealth += amount;
    }
    
    public void DealDamage(int amount)
    {
        ChangeHealth(-amount);
        Instantiate(partSys, transform.position, Quaternion.identity, transform);
    }
}
