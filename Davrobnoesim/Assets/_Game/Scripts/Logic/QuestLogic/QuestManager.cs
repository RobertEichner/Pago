using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<Quest> quests = new List<Quest>();

    [SerializeField] private Quest testQuest = null;
    private void Awake()
    {
        AddQuest(testQuest);
    }

    private void Update()
    {
        foreach (var q in quests)
        {
            if(!q.IsDone)
                q.Task.CheckTask();
        }
    }

    public bool HasQuest(Quest q)
    {
        return quests.Find(item => q == item);
    }
    
    public void AddQuest(Quest q)
    {
        if (!HasQuest(q))
        {
            quests.Add(q);
            q.Task.BeginTask();
        }
    }

    public bool IsQuestDone(Quest q)
    {
        return q.IsDone;
    }

    public void FinishQuest(Quest q)
    {
        if (IsQuestDone(q))
        {
            quests.Remove(q);
            q.Task.EndTask();
        }
    }
}
