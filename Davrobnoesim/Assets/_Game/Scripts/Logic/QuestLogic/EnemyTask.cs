using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/QuestEnemyTask erstellen")]
public class EnemyTask : QuestTask
{
    [SerializeField] private int enemiesToKill = 1;
    private int currentEnemiesKills = 0;

    private void OnEnable()
    {
        currentEnemiesKills = 0;
    }

    public override void CheckTask()
    {
        Debug.Log(currentEnemiesKills);
    }

    public override void BeginTask()
    {
        OnDestroyEvent.DestroyEvent += CheckCond;
    }

    public override void EndTask()
    {
        OnDestroyEvent.DestroyEvent -= CheckCond;
    }

    private void CheckCond(GameObject g)
    {
        currentEnemiesKills++;
    }
}
