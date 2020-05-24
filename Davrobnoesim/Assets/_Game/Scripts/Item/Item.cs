using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private int id;
    private string title;
    private string description;
    private Sprite icon;
    
    public int Id => id;
    public string Title => title;
    public string Description => description;
    public Sprite Icon => icon;

    public Item(int id, string title, string description)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprite/item" + id.ToString());
    }
    
    public Item(int id, string title, string description, Sprite icon)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = icon;
    }
    
    public Item(Item item)
    {
        this.id = item.Id;
        this.title = item.Title;
        this.description = item.Description;
        this.icon = item.Icon;
    }
}
