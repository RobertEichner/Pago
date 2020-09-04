using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyEvent : MonoBehaviour
{
    public delegate void OnDestEvent(GameObject g);

    public static event OnDestEvent DestroyEvent;
    private void OnDestroy()
    {
        DestroyEvent?.Invoke(gameObject);
    }
}
