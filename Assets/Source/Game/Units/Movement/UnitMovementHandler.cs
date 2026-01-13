using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementHandler : IDisposable
{
    private IInput _input;
    private IRigidbodyMovable _rigidbodyMovable;

    public UnitMovementHandler(IInput input, IRigidbodyMovable rigidbodyMovable)
    {
        _input = input;
        _rigidbodyMovable = rigidbodyMovable;
        _input.MoveInputDrag += OnMoveInputReceived;
    }

    public void OnMoveInputReceived(Vector2 value)
    {
        Debug.Log("IMovement Input Receiverd");
        _rigidbodyMovable.Rigidbody.velocity = new Vector3(value.x * _rigidbodyMovable.Speed,
            _rigidbodyMovable.Rigidbody.velocity.y, value.y * _rigidbodyMovable.Speed);
    }

    public virtual void Dispose()
    {
        _input.MoveInputDrag -= OnMoveInputReceived;
    }
}