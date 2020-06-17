using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiste : MonoBehaviour, IInteractable
{
    private bool isOpen = false;

    [SerializeField] private Canvas inv;

    private void Awake()
    {
        inv.enabled = false;
    }

    public void Interact()
    {
        inv.enabled = !inv.enabled;
    }
}
