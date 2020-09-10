using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/QuestChecker")]
public class QuestTextChecker : DialogToFinish
{
    [SerializeField] private Quest quest;

    public override void StoryEvent()
    {
        isDone = QuestManager.Instance.HasQuest(quest);
    }

    public override bool CanBeDone()
    {
        return QuestManager.Instance.HasQuest(quest);
    }
}
