using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemAbilities/DealDamageSword")]
public class DealDamageSword : ItemAbility
{
    [SerializeField] private int damageAmount = 50;

    public override void UseItem(GameObject target)
    {
        Collider2D[] results = new Collider2D[22];
        int hit = Physics2D.OverlapCircleNonAlloc(target.transform.position, 3f, results);

        if (hit < 1)
            return;
        

        //int loopUntil = hit + 1 > results.Length ? results.Length : hit + 1;

        for (int i = 0; i < results.Length; i++)
        {
            if (results[i] == null || results[i].gameObject == target)
                continue;
            if (results[i].TryGetComponent<IDamagable>(out var toInteract))
            {
                toInteract.DealDamage(damageAmount);
                return;
            }
        }
    }
}
