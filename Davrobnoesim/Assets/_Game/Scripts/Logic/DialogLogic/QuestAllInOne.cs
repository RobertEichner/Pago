using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/QuestAllInOne")]
public class QuestAllInOne : State
{
    private State stateToChose = null;

    [SerializeField] private QuestTextGiver giveQuest = null;
    [SerializeField] private QuestTextChecker checkQuest = null;
    [SerializeField] private QuestFinisher finishQuest = null;
    [SerializeField] private State endState = null;

    public override State[] GetNextStates()
    {
        State[] toReturn = new State[1];
        toReturn[0] = stateToChose;
        return toReturn;
    }

    public override void StoryEvent()
    {
        stateToChose = giveQuest;

        if (checkQuest.CanBeDone())
            stateToChose = checkQuest;
        if (finishQuest.CanBeDone())
            stateToChose = finishQuest;
        if (finishQuest.IsDone)
            stateToChose = endState;
    }
}
