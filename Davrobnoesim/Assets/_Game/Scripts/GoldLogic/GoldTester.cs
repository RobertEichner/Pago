using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTester : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<IChangeGold>(out var gold))
        {
            return;
        }
        gold.ChangeGold(10);
    
    }
}
