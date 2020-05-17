using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 direction;

    [SerializeField] private float speed = 8f;

    private void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (direction * (Time.fixedDeltaTime * speed)));
    }

    public void OnMovement(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
