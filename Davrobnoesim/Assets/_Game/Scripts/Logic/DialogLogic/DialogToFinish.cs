﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogToFinish : State
{
    protected bool isDone = false;

    public bool IsDone => isDone;
}
