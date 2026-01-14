using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementHandler : IDisposable
{
    private IPlayerInput _playerInput;
    private IRigidbodyMovable _rigidbodyMovable;

    public UnitMovementHandler(IPlayerInput playerInput, IRigidbodyMovable rigidbodyMovable)
    {
        _playerInput = playerInput;
        _rigidbodyMovable = rigidbodyMovable;
        _playerInput.MoveInputDrag += OnMovePlayerInputReceived;
    }

    public void OnMovePlayerInputReceived(Vector2 value)
    {
        Debug.Log("IMovement Input Receiverd");
        _rigidbodyMovable.Rigidbody.velocity = new Vector3(value.x * _rigidbodyMovable.Speed,
            _rigidbodyMovable.Rigidbody.velocity.y, value.y * _rigidbodyMovable.Speed);
    }

    public virtual void Dispose()
    {
        _playerInput.MoveInputDrag -= OnMovePlayerInputReceived;
    }
}