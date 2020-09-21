using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCollAvoid : MonoBehaviour, IDamagable
{
    [Header("Enemy Stats")]
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float attentionRange = 4f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 100;
    [SerializeField] private LayerMask layerMaskToHit = -1;
    [SerializeField] private float avoidDistance = 0.5f;
    [SerializeField] private float lookAhead = 1f;
    [Header("EnemyDrop Logic")]
    [SerializeField] private Item[] drop = null;
    [SerializeField] private ItemPrefab.ItemState[] state = null;
    [SerializeField] private LayerMask layerToBlockDrop;
    [Header("Enemy effects")]
    [SerializeField] private ParticleSystem[] partSys;
    private bool canAttack = true;
    private Transform target = null;
    private CapsuleCollider2D col;
    private Animator anim = null;
    private float knockbackDur = 0.5f;
    private float currentKnockback = 0;

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

        //LookAtTarget(direction);
        
        anim.SetFloat("xVelocity", direction.x);
        anim.SetFloat("yVelocity", direction.y);
        anim.SetFloat("speed", dist);
        
        if (currentKnockback >= Mathf.Epsilon)
        {
            currentKnockback -= Time.deltaTime;
            transform.position -= direction.normalized * (Time.deltaTime * speed);
        }
        else
        {
            Vector3 ray = direction.normalized * lookAhead;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ray, direction.magnitude, layerToBlockDrop);
            if (!hit)
                transform.position += direction.normalized * (Time.deltaTime * speed);
            else
            {
                Vector3 newTarget = hit.point + hit.normal * avoidDistance;
                Vector3 targetDir = newTarget - transform.position;
                transform.position += targetDir.normalized * (Time.deltaTime * speed);
            }
        }

        if(dist > attackRange)
            return;
        
        Attack(direction);

    }

    public void DealDamage(int amount)
    {
        health -= amount;
        Instantiate(partSys[0], transform.position, Quaternion.identity, transform);
        currentKnockback = currentKnockback >= Mathf.Epsilon ? currentKnockback : knockbackDur;
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
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, 2f, layerMaskToHit);
        
        if(!hit)
            return;
        
        if(hit.collider.TryGetComponent<IDamagable>(out var tar) && hit.collider != col)
            tar.DealDamage(attackDamage);
        
        //anim.SetTrigger("attack");
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
}
