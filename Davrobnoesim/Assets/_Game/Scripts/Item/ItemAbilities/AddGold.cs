using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemAbilities/AddGold")]
public class AddGold : ItemAbility
{
    [SerializeField] private int amount;
    public override void UseItem(GameObject target)
    {
        if (!target.TryGetComponent<IChangeGold>(out var toGiveGold))
        {
            return;
        }
        toGiveGold.ChangeGold(amount);
    }
}
