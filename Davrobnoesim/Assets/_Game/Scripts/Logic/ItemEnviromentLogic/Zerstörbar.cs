using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Zerstörbar : MonoBehaviour, IDamagable
{
    [SerializeField] private int healthAmount = 100;

    public void DealDamage(int amount)
    {
        healthAmount -= amount;
        
        if(healthAmount <=0)
            Destroy(gameObject);
    }
}
