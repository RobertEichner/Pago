using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestTask : ScriptableObject
{
    public abstract void CheckTask();
    public abstract void BeginTask();
    public abstract void EndTask();
}
