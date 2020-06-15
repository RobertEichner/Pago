using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "CreateItem")]
public class Item : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string title;
    [SerializeField] private Sprite icon;

    [SerializeField] private ItemAbility ability;

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Title
    {
        get => title;
        set => title = value;
    }

    public Sprite Icon
    {
        get => icon;
        set => icon = value;
    }

    public ItemAbility Ability
    {
        get => ability;
        set => ability = value;
    }

    public Item CreateClone()
    {
        Item cloneItem = ScriptableObject.CreateInstance<Item>();
        cloneItem.id = this.id;
        cloneItem.title = this.title;
        cloneItem.icon = this.icon;
        cloneItem.ability = this.ability;

        return cloneItem;
    }
}
