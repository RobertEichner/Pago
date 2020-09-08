using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemAbility : ScriptableObject
{
    public abstract void UseItem(GameObject target);
}
