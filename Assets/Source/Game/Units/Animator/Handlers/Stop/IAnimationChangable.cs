using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationChangable
{
    public event Action AnimationChange;
}
