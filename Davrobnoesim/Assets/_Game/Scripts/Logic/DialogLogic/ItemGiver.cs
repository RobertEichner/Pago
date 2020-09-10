using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/ItemGiver")]
public class ItemGiver : DialogToFinish
{
    [SerializeField] private Item item = null;
    public override void StoryEvent()
    {
        Inventory inv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        isDone = inv.GiveItem(item);
    }

    public override bool CanBeDone()
    {
        return true;
    }
}
