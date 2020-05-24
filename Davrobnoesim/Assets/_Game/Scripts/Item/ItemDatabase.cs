using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }
    
    public Item GetItem(int id)
    {
        return items.Find(item => item.Id == id);
    }
    
    public Item GetItem(string title)
    {
        return items.Find(item => item.Title == title);
    }

    private void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item(1,"Goldmünze", "leuchtet gelb"),
            new Item(2, "Lebenstrank", "Heilt Leben")
        };
    }

}
