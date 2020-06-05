using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> characterItems = new List<Item>();
    [SerializeField] private UIInventory uIInventory;
    [SerializeField] private int maxItemSlots = 16;

    private void Awake()
    {
        uIInventory.SetSlots(maxItemSlots);
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
}
