using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiste : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

    [SerializeField] private Canvas inv = null;
    [SerializeField] private float activeInThisRadius = 2f;
    private Transform targetPos = null;
    private void Awake()
    {
        inv.enabled = false;
    }

    public void Interact(GameObject sender)
    {
        isOpen = inv.enabled = !inv.enabled;
        targetPos = sender.transform;
    }

    private void Update()
    {
        if (isOpen)
        {
            if(Vector2.Distance(transform.position, targetPos.position) > activeInThisRadius)
                Interact(gameObject);
        }
    }
}
