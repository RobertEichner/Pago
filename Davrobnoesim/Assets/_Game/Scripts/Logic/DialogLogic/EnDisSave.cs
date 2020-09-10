using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Saves/ObjectDisableEnable")]
public class EnDisSave : ScriptableObject
{
    public enum IntState
    {
        INITIAL, CHANGED
    }

    [SerializeField] private IntState state;

    public IntState State
    {
        get => state;
        set => state = value;
    }

    private void OnEnable()
    {
        //state = IntState.INITIAL;
    }
}
