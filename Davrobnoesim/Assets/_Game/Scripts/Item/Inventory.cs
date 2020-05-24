using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> characterItems = new List<Item>();
    [SerializeField] private ItemDatabase itemDatabase;
    [SerializeField] private UIInventory uIInventory;

    private void Start()
    {
        GiveItem(1);
        GiveItem(2);
    }

    public void GiveItem(int id)
    {
        Item itemAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemAdd);
        uIInventory.AddItem(itemAdd);
    }
    
    public void GiveItem(string name)
    {
        Item itemAdd = itemDatabase.GetItem(name);
        characterItems.Add(itemAdd);
        uIInventory.AddItem(itemAdd);
    }
    
    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.Id == id);
    }
    
    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);

        if (itemToRemove != null)
        {
            characterItems.Remove(itemToRemove);
            uIInventory.RemoveItem(itemToRemove);
        }
    }
}
