using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Kiste : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

    [SerializeField] private Canvas inv = null;
    [SerializeField] private float activeInThisRadius = 2f;
    [SerializeField] private KisteSave invSave = null;

    private Transform targetPos = null;
    private Inventory invToFill;
    
    private void Awake()
    {
        inv.enabled = false;
        TryGetComponent(out invToFill);
    }

    private void Start()
    {
        if(invSave == null)
            return;

        for (int i = 0; i < invSave.ItemList.Length; i++)
        {
            invToFill.GiveItemAt(invSave.ItemList[i], i);
        }
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

    private void OnDestroy()
    {
        invSave.ItemList = invToFill.GetItemArray();
    }
}
