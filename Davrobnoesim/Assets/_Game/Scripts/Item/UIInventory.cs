using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private readonly List<UIItem> uIItems = new List<UIItem>();
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotPanel;
    private int numberOfSlots = 0;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
        }
    }

    private void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.Item == null), item);
    }
    
    public void RemoveItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.Item == item), null);
    }

    public void SetSlots(int i)
    {
        numberOfSlots = i;
    }
}
