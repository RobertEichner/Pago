using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    [SerializeField] private int goldValue = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<IChangeGold>(out var gold))
        {
            return;
        }
        
        gold.ChangeGold(goldValue);
        Destroy(gameObject);
    }
}
