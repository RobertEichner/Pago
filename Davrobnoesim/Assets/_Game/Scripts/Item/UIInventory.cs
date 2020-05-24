using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    private readonly List<UIItem> uIItems = new List<UIItem>();
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotPanel;
    [SerializeField] private int numberOfSlots = 16;

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
}
