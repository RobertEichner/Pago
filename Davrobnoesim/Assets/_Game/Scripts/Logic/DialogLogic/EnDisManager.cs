using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDisManager : MonoBehaviour
{
    [SerializeField] private GameObject[] toEnable = null;
    [SerializeField] private GameObject[] toDisable = null;
    [SerializeField] private EnDisSave save;
    

    private void Awake()
    {
        if(save.State == EnDisSave.IntState.INITIAL)
            SwitchStates(false);
        else
            SwitchStates(true);
    }
    
    public void SwitchStates(bool switchTo)
    {
        foreach (var obj in toEnable)
        {
            obj.SetActive(switchTo);
        }
        
        foreach (var obj in toDisable)
        {
            obj.SetActive(!switchTo);
        }

        save.State = switchTo ? EnDisSave.IntState.CHANGED : EnDisSave.IntState.INITIAL;
    }
}
