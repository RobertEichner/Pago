using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    [SerializeField] private bool isAnchor = false;
    [TextArea(10,14)][SerializeField] private string storyText;
    [SerializeField] private State[] nextStates;
    public bool IsAnchor => isAnchor;
    
    public virtual string GetStateStory()
    {
        return storyText;
    }

    public virtual State[] GetNextStates()
    {
        return nextStates;
    }

    public void ClearNextStates()
    {
        nextStates = null;
    }

    public abstract void StoryEvent();
}