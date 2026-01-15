using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRotationHandler : IDisposable
{
    protected IUnitInput unitInput;
    protected IUnitTransformable unitTransformable;

    public UnitRotationHandler(IUnitInput unitInput, IUnitTransformable unitTransformable)
    {
        this.unitInput = unitInput;
        this.unitTransformable = unitTransformable;
        this.unitInput.RotateInputDrag += OnRotateInputReceived;
    }

    protected virtual void OnRotateInputReceived(Vector2 value)
    {
    }

    public void Dispose()
    {
        unitInput.RotateInputDrag -= OnRotateInputReceived;
    }
}