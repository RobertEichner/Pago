using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog/FinishedXQuests")]
public class FinishXQuests : DialogToFinish
{
    [SerializeField] private Quest[] quests;
    public override void StoryEvent()
    {
        isDone = CanBeDone();
    }

    public override bool CanBeDone()
    {
        foreach (var quest in quests)
        {
            if (!quest.IsDone)
            {
                return false;
            }
        }

        return true;
    }
}
