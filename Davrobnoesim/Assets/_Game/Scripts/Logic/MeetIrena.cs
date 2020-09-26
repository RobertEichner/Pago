using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetIrena : MonoBehaviour
{
    [SerializeField] private Quest quest;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !quest.IsDone)
        {
            QuestManager qm = other.GetComponent<QuestManager>();
            qm.AddQuest(quest);
            qm.FinishQuest(quest);
        }
    }
}
