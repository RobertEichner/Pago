using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPlant : MonoBehaviour, IDamagable
{
    [Header("Enemy Stats")]
    [SerializeField] private int health = 100;
    [SerializeField] private float attentionRange = 4f;
    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private int attackDamage = 10;
    [Header("EnemyDrop Logic")]
    [SerializeField] private LayerMask layerToBlockDrop;
    [SerializeField] private Item[] drop = null;
    [SerializeField] private ItemPrefab.ItemState[] state = null;
    [Header("Enemy effects")]
    [SerializeField] private ParticleSystem[] partSys;
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
            HandleDrop();
        }
    }
    
    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        anim.SetBool("attacking", false);
        canAttack = true;
    }
    
    private void HandleDrop()
    {
        if(drop == null || state == null)
            return;

        if(state.Length != drop.Length)
            throw new Exception("ArrayLänge von Drop und State stimmen nicht überein");
        for (int i = 0; i < drop.Length; i++)
        {
            float xOff = Random.Range(-1f, 1f);
            float yOff = Random.Range(-1f, 1f);
            Vector3 offset = new Vector3(xOff, yOff, 0);
            GameObject itemToSpawn = Resources.Load<GameObject>("Prefabs/WorldItemCollectable");
            if (itemToSpawn.TryGetComponent<ItemPrefab>(out var itemPrefab))
                itemPrefab.UpdateItem(drop[i], state[i]);
            
            if(!Physics2D.Raycast(transform.position, (transform.position + offset) - transform.position, 2f, layerToBlockDrop))
                Instantiate(itemToSpawn, transform.position + offset, Quaternion.identity);
            else
            {
                Vector3 newPos = target.position - (transform.position + offset);
                Instantiate(itemToSpawn, RayCastCrossPlayer(newPos), Quaternion.identity);
            }
        }
    }
    
    private Vector3 RayCastCrossPlayer(Vector3 direction)
    {
        if (!Physics2D.Raycast(target.position, direction, 2f, layerToBlockDrop))
            return target.position + direction.normalized;
        if (!Physics2D.Raycast(target.position, -direction, 2f, layerToBlockDrop))
            return target.position - direction.normalized;
        Vector3 rotDir = Quaternion.AngleAxis(45f, Vector3.up) * direction;
        if (!Physics2D.Raycast(target.position, rotDir, 2f, layerToBlockDrop))
            return target.position + rotDir.normalized;
        if (!Physics2D.Raycast(target.position, -rotDir, 2f, layerToBlockDrop))
            return target.position - rotDir.normalized;

        return target.position;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<IDamagable>(out var dmg))
        {
            dmg.DealDamage(attackDamage);
        }
        
    }
}
