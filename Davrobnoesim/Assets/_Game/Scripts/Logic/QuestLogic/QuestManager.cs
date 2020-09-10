using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class QuestManager
{
    private static QuestManager instance = null;

    public static QuestManager Instance
    {
        get
        {
            if (instance==null)
            {
                instance = new QuestManager();
            }
            return instance;
        }
    }

    private List<Quest> quests = new List<Quest>();

    private QuestManager()
    {
        
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
    

    public bool FinishQuest(Quest q)
    {
        if (IsQuestDone(q))
        {
            quests.Remove(q);
            q.Task.EndTask();
            return true;
        }

        return false;
    }
}
