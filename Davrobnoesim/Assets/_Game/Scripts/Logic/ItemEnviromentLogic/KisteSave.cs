using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Saves/Kiste")]
public class KisteSave : ScriptableObject
{
    [SerializeField] private Item[] initialItemList = null;
    
    public Item[] ItemList { get; set; } = null;

    private void OnEnable()
    {
        ItemList = initialItemList;
    }
}
