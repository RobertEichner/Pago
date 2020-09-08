using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/QuestEnemyTask erstellen")]
public class EnemyTask : QuestTask
{
    [SerializeField] private EnemyType typeToCheck = EnemyType.NONE;
    [SerializeField] private int enemiesToKill = 1;
    private int currentEnemiesKills = 0;

    private void OnEnable()
    {
        currentEnemiesKills = 0;
    }

    public override bool CheckTaskDone()
    {
        return currentEnemiesKills >= enemiesToKill;
    }

    public override void BeginTask()
    {
        OnDestroyEvent.DestroyEvent += CheckCond;
    }

    public override void EndTask()
    {
        OnDestroyEvent.DestroyEvent -= CheckCond;
    }

    private void CheckCond(GameObject g, EnemyType type)
    {
        if(type == typeToCheck)
            currentEnemiesKills++;
    }
}
