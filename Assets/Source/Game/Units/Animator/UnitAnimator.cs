using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitAnimator
{
    public Animator Animator { get; private set; }

    public UnitAnimator(Animator animator)
    {
        Animator = animator;
    }
}