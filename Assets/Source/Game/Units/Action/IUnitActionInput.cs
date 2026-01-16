using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitActionInput
{
    public event Action StartAction;
    public event Action StopAction;
}