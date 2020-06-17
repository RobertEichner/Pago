using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<int, Item> itemsInInv = new Dictionary<int, Item>();
    [SerializeField] private UIInventory uIInventory = null;
    [SerializeField] private int maxItemSlots = 1;
    private GameObject owner;
    public event EventHandler<ItemChangeArgs> OnItemChanged;

    public class ItemChangeArgs : EventArgs
    {
        public Item Item { get; set; }
        public int Index { get; set; }
    }

    private void Awake()
    {
        owner = gameObject;
        uIInventory.SetSlots(maxItemSlots);
        uIInventory.SetInventory(this);
    }
    

    public Item GetItemFromIndex(int index)
    {
        if (itemsInInv.ContainsKey(index) && itemsInInv[index] != null)
            return itemsInInv[index];
        return null;
    }
    
    private void ItemChange(Item item, int i)
    {
        OnItemChanged?.Invoke(this, new ItemChangeArgs
        {
            Item = item,
            Index = i
        });
    }

    public bool GiveItem(Item item)
    {
        for (int i = 0; i < maxItemSlots; i++)
        {
            if (itemsInInv.ContainsKey(i) == false || itemsInInv[i] == null)
            {
                itemsInInv[i] = item;
                ItemChange(item, i);
                return true;
            }
        }
        return false;
    }
    

    public bool GiveItemAt(Item item, int index)
    {
        if (index < maxItemSlots && index >= 0 && (itemsInInv.ContainsKey(index) == false || itemsInInv[index] == null))
        {
            itemsInInv[index] = item;
            ItemChange(item, index);
            return true;
        }
        return false;
    }

    public void RemoveItem(int index)
    {
        if (GetItemFromIndex(index) != null)
        {
            itemsInInv[index] = null;
            ItemChange(null, index);
        }
    }

    public void OverrideItem(Item item, int index)
    {
        itemsInInv[index] = item;
        ItemChange(item, index);
    }

    public void SwapItems(Inventory toInventory, int toIndex, int fromIndex)
    {
        Item item1 = GetItemFromIndex(fromIndex); 
        Item item2 = toInventory.GetItemFromIndex(toIndex);
        
        RemoveItem(fromIndex);
        toInventory.RemoveItem(toIndex);

        GiveItemAt(item2, fromIndex);
        toInventory.GiveItemAt(item1, toIndex);

        //OverrideItem(item2, fromIndex);
        //toInventory.OverrideItem(item1, toIndex);

        toInventory.ItemChange(item1, toIndex);
    }

    public void UseSlot(int index)
    {
        if (itemsInInv.ContainsKey(index) && itemsInInv[index] != null)
        {
            itemsInInv[index].Ability.UseItem(owner);
            RemoveItem(index);
        }
        
    }

    public void UpdateAllSlots()
    {
        for (int i = 0; i < maxItemSlots; i++)
        {
            if(!itemsInInv.ContainsKey(i) || itemsInInv[i] == null)
                break;
            ItemChange(itemsInInv[i], i);
        }
    }
}
