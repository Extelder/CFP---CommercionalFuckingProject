using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitCutDownAnimatorHandler : IDisposable
{
    private IPlayerUnitCutDownInput _input;
    private IUnitCutDownAnimatorInput _unitCutDownAnimatorInput;

    private UnitAnimator _unitAnimator;

    public PlayerUnitCutDownAnimatorHandler(IPlayerUnitCutDownInput input,
        IUnitCutDownAnimatorInput unitCutDownAnimatorInput, UnitAnimator animator)
    {
        _input = input;

        _unitAnimator = animator;
        _unitCutDownAnimatorInput = unitCutDownAnimatorInput;
        _input.StartAction += OnCutDownStarted;
        _input.StopAction += OnCutDownStopped;
    }

    private void OnCutDownStopped()
    {
        _unitAnimator.Animator.SetBool(_unitCutDownAnimatorInput.CuttingDownBoolName, false);
    }

    private void OnCutDownStarted()
    {
        _unitAnimator.Animator.SetBool(_unitCutDownAnimatorInput.CuttingDownBoolName, true);
    }

    public void Dispose()
    {
        _input.StartAction -= OnCutDownStarted;
        _input.StopAction -= OnCutDownStopped;
    }
}