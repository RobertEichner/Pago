using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemAbilities/DealDamageSword")]
public class DealDamageSword : ItemAbility
{
    [SerializeField] private int damageAmount = 50;
    [SerializeField] private LayerMask layerMask;
    
    private  PlayerMovement player = null;
    public override void UseItem(GameObject target)
    {

        if(target.TryGetComponent<Animator>(out var anim))
            anim.SetTrigger("attack");
        
        target.TryGetComponent(out player);
        Vector2 dir = player != null ? player.Direction : Vector2.right;
       

        RaycastHit2D hit = Physics2D.CircleCast(target.transform.position, 0.25f, dir * 0.1f, 1f, layerMask);

        if (hit.collider != null)
        {
            if(hit.collider.TryGetComponent<IDamagable>(out var damagable))
                damagable.DealDamage(damageAmount);
        }
    }
}
