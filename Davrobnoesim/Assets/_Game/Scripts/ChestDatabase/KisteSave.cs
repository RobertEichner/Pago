using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kiste ItemListe")]
public class KisteSave : ScriptableObject
{
    [SerializeField] private Item[] itemList = null;

    public Item[] ItemList
    {
        get => itemList;
        set => itemList = value;
    }
}
