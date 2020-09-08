using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Quest erstellen")]
public class Quest: ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private QuestTask task;
    private bool isDone = false;
    public string Name => name;

    public string Description => description;

    public QuestTask Task => task;
    
    public bool IsDone
    {
        get
        {
            isDone = task.CheckTaskDone();
            return isDone;
        }
    }
}
