using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/DynamicText")]
public class DynamicText : State
{
    [SerializeField] private State[] stateChoices;
    
    private State stateToChose = null;
    
    public override string GetStateStory()
    {
        return ChooseStateStory();
    }

    public override State[] GetNextStates()
    {
        return ChooseNextSates();
    }
    public override void StoryEvent()
    {
    }

    private string ChooseStateStory()
    {
        return base.GetStateStory();
    }

    private State[] ChooseNextSates()
    {
        return base.GetNextStates();
    }
}
