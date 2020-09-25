using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/QuestFinisher")]
public class QuestFinisher : DialogToFinish
{
    [SerializeField] private Quest quest;

    [SerializeField] private Item itemToRemove = null;

    public override void StoryEvent()
    {
        isDone = QuestManager.Instance.FinishQuest(quest);

        if (isDone && itemToRemove != null)
        {
            Inventory[] invs = GameObject.FindWithTag("Player").GetComponents<Inventory>();

            foreach (var inventory in invs)
            {
                inventory.RemoveItem(itemToRemove);
            }
        }
    }

    public override bool CanBeDone()
    {
        return QuestManager.Instance.IsQuestDone(quest);
    }
}
