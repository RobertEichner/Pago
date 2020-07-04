using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float interactRadius = 1f;
    [SerializeField] private GameObject inventarToOpen = null;
    [SerializeField] private Inventory hotbarInventory = null;
    private bool isOpen = false;


    private void Awake()
    {
        inventarToOpen.SetActive(isOpen);
    }

    private void OnInteract(InputValue value)
    {
        Collider2D[] results = new Collider2D[20];
        int hit = Physics2D.OverlapCircleNonAlloc(transform.position, interactRadius, results);

        if (hit < 1)
            return;

        //int loopUntil = hit + 1 > results.Length ? results.Length : hit + 1;

        for (int i = 0; i < results.Length; i++)
        {
            if(results[i] == null)
                continue;
            if (results[i].TryGetComponent<IInteractable>(out var toInteract))
            {
                toInteract.Interact(gameObject);
                return;
            }
        }
    }
    
    private void OnHotbarAttackLeft(InputValue value)
    {
        if(IsOverUI())
            return;
        hotbarInventory.UseSlot(0);
    }
    
    private void OnHotbarAttackRight(InputValue value)
    {
        if(IsOverUI())
            return;
        hotbarInventory.UseSlot(1);
    }

    private void OnInventarOpen(InputValue value)
    {
        isOpen = !isOpen;
        inventarToOpen.SetActive(isOpen);
        

        if (isOpen && inventarToOpen.TryGetComponent<UIInventory>(out var toInv))
        {
            toInv.OwnerInv.UpdateAllSlots();
        }
    }

    private bool IsOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void OnEscape(InputValue value)
    {
        Application.Quit();
    }
}
