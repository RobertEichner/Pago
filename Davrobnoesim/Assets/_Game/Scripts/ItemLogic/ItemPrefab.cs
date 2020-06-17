using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemPrefab : MonoBehaviour
{

    private SpriteRenderer sRenderer;

    [SerializeField] private Item item = null;
    [SerializeField] private ItemState triggerToDo;
    
    // Start is called before the first frame update
    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sRenderer.sprite = item.Icon;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (triggerToDo)
        {
            case ItemState.ToInventory:
                ItemToInventory(other);
                break;
            case ItemState.ToUse:
                ItemToUse(other);
                break;
        }
    }

    private void ItemToInventory(Collider2D other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inv))
        {
            if (inv.GiveItem(item))
                Destroy(gameObject);
        }
    }
    
    private void ItemToUse(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            item.Ability.UseItem(other.gameObject);
            Destroy(gameObject);
        }
    }

    private enum ItemState
    {
        ToInventory,
        ToUse,
    }
    
}
