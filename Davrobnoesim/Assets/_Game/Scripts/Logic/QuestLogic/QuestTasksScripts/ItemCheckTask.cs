using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Quest/ItemCheckTask erstellen")]
public class ItemCheckTask : QuestTask
{
    [SerializeField] private Item itemToCheck = null;

    private Inventory[] inventories = null;
    public override bool CheckTaskDone()
    {
        if (inventories == null)
            return false;
        
        foreach (var inventory in inventories)
        {
            if (inventory.HasItem(itemToCheck))
                return true;
        }

        return false;
    }

    public override void BeginTask()
    {
        inventories = GameObject.FindWithTag("Player").GetComponents<Inventory>();
    }

    public override void EndTask()
    {
        inventories = null;
    }
}
