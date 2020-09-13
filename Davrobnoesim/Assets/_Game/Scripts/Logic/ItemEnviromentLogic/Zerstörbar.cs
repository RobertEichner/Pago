using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider2D))]
public class Zerstörbar : MonoBehaviour, IDamagable
{
    [SerializeField] private int healthAmount = 100;
    [Header("Drop Logic")]
    [SerializeField] private Item[] drop = null;
    [SerializeField] private ItemPrefab.ItemState[] state = null;

    public void DealDamage(int amount)
    {
        healthAmount -= amount;

        if (healthAmount <= 0)
            Death();
    }

    private void Death()
    {
        HandleDrop();
        Destroy(gameObject);
    }
    
    private void HandleDrop()
    {
        if(drop == null || state == null)
            return;

        if(state.Length != drop.Length)
            throw new Exception("ArrayLänge von Drop und State stimmen nicht überein");
        for (int i = 0; i < drop.Length; i++)
        {
            GameObject itemToSpawn = Resources.Load<GameObject>("Prefabs/WorldItemCollectable");
            if (itemToSpawn.TryGetComponent<ItemPrefab>(out var itemPrefab))
                itemPrefab.UpdateItem(drop[i], state[i]);
            Instantiate(itemToSpawn, transform.position, Quaternion.identity);
           
        }
    }


}
