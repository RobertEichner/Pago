using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/QuestChecker")]
public class QuestTextChecker : State
{
    [SerializeField] private Quest quest;
    
    private bool isDone = false;

    public bool IsDone => isDone;

    public override void StoryEvent()
    {
        isDone = QuestManager.Instance.FinishQuest(quest);
    }
}
