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
    
    public string GetStateStory()
    {
        return storyText;
    }

    public State[] GetNextStates()
    {
        return nextStates;
    }

    public abstract void StoryEvent();
}