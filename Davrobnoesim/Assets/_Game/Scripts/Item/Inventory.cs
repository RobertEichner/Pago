using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> characterItems = new List<Item>();
    [SerializeField] private UIInventory uIInventory;
    [SerializeField] private int maxItemSlots = 16;

    private GameObject owner;
    
    private void Awake()
    {
        owner = gameObject;
        uIInventory.SetSlots(maxItemSlots);
    }

    private void Start()
    {
        foreach (var item in uIInventory.UIItems)
        {
            item.SetUseItemAction(UseItem);
        }
    }

    public void GiveItem(Item item)
    {
        characterItems.Add(item);
        uIInventory.AddItem(item);
    }
    
    public Item CheckForItem(Item item)
    {
        return characterItems.Find(i => i == item);
    }
    
    public void RemoveItem(Item item)
    {
        Item itemToRemove = CheckForItem(item);

        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            uIInventory.RemoveItem(itemToRemove);
        }
    }
    
    public void UseItem(Item item)
    {
        Item itemToUse = CheckForItem(item);
        itemToUse.Ability.UseItem(owner);
        RemoveItem(itemToUse);
    }
}
