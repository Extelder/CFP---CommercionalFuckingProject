using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractProduct : MonoBehaviour
{
    public abstract void Init();
    public abstract event Action Initialized;
}
