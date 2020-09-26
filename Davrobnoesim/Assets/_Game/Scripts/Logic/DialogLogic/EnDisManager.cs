using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnDisManager : MonoBehaviour
{
    [SerializeField] private GameObject toEnable = null;
    [SerializeField] private GameObject toDisable = null;
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

        if (switchTo)
        {
            toDisable.transform.position = new Vector3(53.5f, 15, 0);
            toEnable.transform.position = new Vector3(100, -100, 0);
        }
        else
        {
            toDisable.transform.position = new Vector3(100, -100, 0);
            toEnable.transform.position = new Vector3(-6.5f, 5.5f, 0);
        }


        save.State = switchTo ? EnDisSave.IntState.CHANGED : EnDisSave.IntState.INITIAL;
    }
}
