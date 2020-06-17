using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private float interactRadius = 1f;
    private void OnInteract(InputValue value)
    {
        Collider2D[] results = new Collider2D[22];
        int hit = Physics2D.OverlapCircleNonAlloc(transform.position, interactRadius, results);

        if (hit < 1)
            return;

        for (int i = 0; i < results.Length; i++)
        {
            if(results[i] == null)
                break;
            if (results[i].TryGetComponent<IInteractable>(out var toInteract))
            {
                toInteract.Interact();
            }
        }
    }
    
    private void OnHotbarAttackLeft(InputValue value)
    {
        Debug.Log("Links");
    }
    
    private void OnHotbarAttackRight(InputValue value)
    {
        Debug.Log("Rechts");
    }
}
