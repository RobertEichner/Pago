using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/QuestFinisher")]
public class QuestFinisher : DialogToFinish
{
    [SerializeField] private Quest quest;

    public override void StoryEvent()
    {
        isDone = QuestManager.Instance.FinishQuest(quest);
    }

    public override bool CanBeDone()
    {
        return QuestManager.Instance.IsQuestDone(quest);
    }
}
