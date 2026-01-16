using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProduct : AbstactProduct
{
    public override void Init()
    {
        Initialized?.Invoke();
    }

    public override event Action Initialized;
}
