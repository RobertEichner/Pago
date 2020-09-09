using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlant : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 100;
    [SerializeField] private float attentionRange = 4f;
    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private ParticleSystem[] partSys;
    [SerializeField] private Item[] drop = null;
    [SerializeField] private ItemPrefab.ItemState[] state = null;
    private bool canAttack = true;
    private Transform target = null;
    private Animator anim = null;
    private ParticleSystem partAttack = null;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        TryGetComponent(out anim);
        TryGetComponent(out partAttack);
    }

    // Update is called once per frame
    void Update()
    {
        var direction =  target.position - transform.position;
        float dist = direction.magnitude;
        
        if(dist > attentionRange)
            return;
        Attack();
        

    }
    
    private void Attack()
    {
        if(!canAttack)
            return;
        
        partAttack.Play();
        anim.SetBool("attacking", true);
        canAttack = false;
        StartCoroutine(WaitForAttack());

    }

    public void DealDamage(int amount)
    {
        health -= amount;
        Instantiate(partSys[0], transform.position, Quaternion.identity, transform);
        if (health <= 0)
        {
            Instantiate(partSys[1], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        anim.SetBool("attacking", false);
        canAttack = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<IDamagable>(out var dmg))
        {
            dmg.DealDamage(attackDamage);
        }
        
    }
}
