using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/EnterTask erstellen")]
public class EnterTask : QuestTask
{
    public override bool CheckTaskDone()
    {
        return true;
    }

    public override void BeginTask()
    {
    }

    public override void EndTask()
    {
    }
}
