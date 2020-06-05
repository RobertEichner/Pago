using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemPrefab : MonoBehaviour
{

    private SpriteRenderer renderer;
    private BoxCollider2D col;

    [SerializeField] private Item item;
    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        renderer.sprite = item.Icon;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Inventory>(out Inventory inv))
        {
            inv.GiveItem(item);
            Destroy(gameObject);
        }
    }
}
