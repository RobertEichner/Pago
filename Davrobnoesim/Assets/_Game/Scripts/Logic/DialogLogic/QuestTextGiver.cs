using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/QuestGiver")]
public class QuestTextGiver : State
{
    [SerializeField] private Quest quest;
    public override void StoryEvent()
    {
        QuestManager.Instance.AddQuest(quest);
    }
}
