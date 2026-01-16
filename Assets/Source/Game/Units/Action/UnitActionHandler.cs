using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitActionHandler : IDisposable
{
    private IUnitActionInput unitActionInput;

    public UnitActionHandler(IUnitActionInput unitActionInput)
    {
        this.unitActionInput = unitActionInput;

        unitActionInput.StartAction += OnActionStarted;
        unitActionInput.StopAction += OnActionStopped;
    }

    protected abstract void OnActionStarted();

    protected abstract void OnActionStopped();

    public void Dispose()
    {
        unitActionInput.StartAction -= OnActionStarted;
        unitActionInput.StopAction -= OnActionStopped;
    }
}