using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemAbilities/HealHealth")]
public class HealHealth : ItemAbility
{
    [SerializeField] private int healthToAdd = 10;
    public override void UseItem(GameObject target)
    {
        if(target.TryGetComponent<PlayerHealth>(out var playerHealth))
            playerHealth.ChangeHealth(healthToAdd);
    }
}
    
