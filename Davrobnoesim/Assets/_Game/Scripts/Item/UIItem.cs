using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    private Item item;
    private Image spriteImage;
    private UIItem selectedItem;
    
    //TODO
    private Inventory inv;
    

    public Item Item => item;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();

    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.Icon;
        }
        else
        {
            spriteImage.color = Color.clear;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (this.item != null)
            {
                if (selectedItem.Item != null)
                {
                    Item clone = selectedItem.item.CreateClone();
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(clone);
                }
                else
                {
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(null);
                }
            }
            else if (selectedItem.Item != null)
            {
                UpdateItem(selectedItem.Item);
                selectedItem.UpdateItem(null);
            }
        }
        else
        {
            if (this.item != null)
            {
               inv.UseItem(this.item);
            }
        }
    }

    public void SetInventory(Inventory inv)
    {
        this.inv = inv;
    }
}
