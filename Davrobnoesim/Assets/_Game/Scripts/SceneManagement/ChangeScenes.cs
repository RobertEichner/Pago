using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] private int scene = 0;
    [SerializeField] private float x, y = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Fading fad = GameObject.Find("Transition").GetComponent<Fading>();
            fad.StartTrans(x,y, other.gameObject, scene, null);
        }
    }
}
