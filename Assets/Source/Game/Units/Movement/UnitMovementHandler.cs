using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementHandler : IDisposable
{
    private IUnitInput _playerInput;
    protected IRigidbodyMovable rigidbodyMovable;

    public UnitMovementHandler(IUnitInput unitInput, IRigidbodyMovable rigidbodyMovable)
    {
        _playerInput = unitInput;
        this.rigidbodyMovable = rigidbodyMovable;
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