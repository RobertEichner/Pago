using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEvent : MonoBehaviour
{
    [SerializeField] private EnemyType type = EnemyType.NONE;
    public delegate void OnDestEvent(GameObject g, EnemyType type);
    

    public static event OnDestEvent DestroyEvent;
    private void OnDestroy()
    {
        DestroyEvent?.Invoke(gameObject, type);
    }
}
