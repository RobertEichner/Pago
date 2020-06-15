using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemPrefab : MonoBehaviour
{

    private SpriteRenderer sRenderer;

    [SerializeField] private Item item = null;
    // Start is called before the first frame update
    void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        sRenderer.sprite = item.Icon;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inv))
        {
            if(inv.GiveItem(item))
                Destroy(gameObject);
        }
    }
}
