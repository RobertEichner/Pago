using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySimple : MonoBehaviour, IDamagable
{

    [SerializeField] private int health = 100;
    [SerializeField] private ParticleSystem[] partSys;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float attentionRange = 4f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 100;
    [SerializeField] private LayerMask layerMask = -1;
    [SerializeField] private Item[] drop = null;
    [SerializeField] private ItemPrefab.ItemState[] state = null;
    
    private bool canAttack = true;
    private Transform target = null;
    private CapsuleCollider2D col;
    private Animator anim = null;
    
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        TryGetComponent(out col);
        TryGetComponent(out anim);
    }

    // Update is called once per frame
    void Update()
    {
        var direction =  target.position - transform.position;
        float dist = direction.magnitude;
        
        if(dist > attentionRange)
            return;

        LookAtTarget(direction);
        transform.position += direction.normalized * (Time.deltaTime * speed);
        
        if(dist > attackRange)
            return;
        
        Attack(direction);
           
        
        
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

    private void Attack(Vector2 direction)
    {
        if(!canAttack)
            return;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, 2f, layerMask);
        
        if(!hit)
            return;
        
        if(hit.collider.TryGetComponent<IDamagable>(out var tar) && hit.collider != col)
            tar.DealDamage(attackDamage);
        
        anim.SetTrigger("attack");
        canAttack = false;
        StartCoroutine(WaitForAttack());

    }

    private void LookAtTarget(Vector2 distance)
    {
        if (distance.x < 0 && transform.right.x > 0)
        {
            transform.Rotate(Vector3.up, 180f);    
        }
        else if(distance.x >0 && transform.right.x < 0)
        {
            transform.Rotate(Vector3.up, 180f);
        }
    }

    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
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
            float xOff = Random.value;
            float yOff = Random.value;
            Vector3 offset = new Vector3(xOff, yOff, 0);
            GameObject itemToSpawn = Resources.Load<GameObject>("Prefabs/WorldItemCollectable");
            if (itemToSpawn.TryGetComponent<ItemPrefab>(out var itemPrefab))
                itemPrefab.UpdateItem(drop[i], state[i]);
            Instantiate(itemToSpawn, transform.position + offset, Quaternion.identity);
        }
    }
}
