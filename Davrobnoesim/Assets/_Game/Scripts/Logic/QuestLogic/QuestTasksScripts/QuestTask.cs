using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestTask : ScriptableObject
{
    public abstract bool CheckTaskDone();
    public abstract void BeginTask();
    public abstract void EndTask();
}
