using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedGrove : MonoBehaviour
{
    [SerializeField] int xBehaviour;
    [SerializeField] int yBehaviour;

    private static int[] pos = new int[2] {0,0};

    public void OnTriggerEnter2D()
    {
        pos[0] = pos[0] + xBehaviour;
        pos[1] = pos[1] + yBehaviour;
        Debug.Log("Position: " + pos[0] + ", " + pos[1]);
    }
}
