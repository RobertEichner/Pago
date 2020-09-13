using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory[] invs = other.GetComponents<Inventory>();
            foreach (var inv in invs)
            {
                inv.Clear();
            }
        }
    }
}
