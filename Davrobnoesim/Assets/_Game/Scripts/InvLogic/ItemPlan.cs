using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Item")]
public class ItemPlan : ScriptableObject
{
    [SerializeField] private string titel = "default";
    [SerializeField] private Sprite icon = null;
    [Min(1)] [SerializeField] private int maxStack = 1;

    public string Titel => titel;
    public Sprite Icon => icon;
    public int MaxStack => maxStack;   
    
}
