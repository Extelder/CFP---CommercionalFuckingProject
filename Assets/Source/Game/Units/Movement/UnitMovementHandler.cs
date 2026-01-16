using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementHandler : IDisposable
{
    private IUnitInput _unitInput;


    public UnitMovementHandler(IUnitInput unitInput)
    {
        _unitInput = unitInput;
        _unitInput.MoveInputDrag += OnMoveUnitInputReceived;
    }

    public virtual void OnMoveUnitInputReceived(Vector2 value)
    {
    }

    public virtual void Dispose()
    {
        _unitInput.MoveInputDrag -= OnMoveUnitInputReceived;
    }
}