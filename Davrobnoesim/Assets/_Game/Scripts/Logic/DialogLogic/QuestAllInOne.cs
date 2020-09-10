using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAllInOne : State
{
    private State stateToChose = null;
    private bool hasQuest = false;
    
    [SerializeField] private QuestTextGiver giveQuest = null;
    [SerializeField] private QuestTextChecker checkQuest = null;
    [SerializeField] private QuestFinisher finishQuest = null;

    public override State[] GetNextStates()
    {
        State[] toReturn = new State[1];
        toReturn[0] = stateToChose;
        return toReturn;
    }

    public override void StoryEvent()
    {
    }
}
