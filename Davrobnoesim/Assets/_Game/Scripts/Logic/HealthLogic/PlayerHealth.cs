using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
         
            if(currentHealth <= 0)
                Death();
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

    private void Death()
    {
        Fading fad = GameObject.Find("Transition").GetComponent<Fading>();
        fad.StartTrans(10,-48, gameObject, 3, AfterDeath);
    }

    private void AfterDeath()
    {
        IChangeGold goldMan;
        TryGetComponent<IChangeGold>(out goldMan);
        goldMan.ChangeGold(-10);
        ChangeHealth(maxHealth);
    }
}
