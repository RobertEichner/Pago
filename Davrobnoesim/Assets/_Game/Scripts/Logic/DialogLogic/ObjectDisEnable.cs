using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/DisEnDialog")]
public class ObjectDisEnable : State

{
    private EnDisManager man = null;

    private void OnEnable()
    {
        //man = GameObject.Find("EnableDisableManager").GetComponent<EnDisManager>();
    }

    public override void StoryEvent()
    {
        man = GameObject.Find("EnableDisableManager").GetComponent<EnDisManager>();
        man.SwitchStates(true);
    }

}
