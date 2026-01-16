using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementHandler : IDisposable
{
    private IUnitInput _playerInput;


    public UnitMovementHandler(IUnitInput unitInput)
    {
        _playerInput = unitInput;
        _playerInput.MoveInputDrag += OnMovePlayerInputReceived;
    }

    public virtual void OnMovePlayerInputReceived(Vector2 value)
    {
    }

    public virtual void Dispose()
    {
        _playerInput.MoveInputDrag -= OnMovePlayerInputReceived;
    }
}