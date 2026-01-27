using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitMovementHandler : UnitMovementHandler
{
    protected IRigidbodyMovable rigidbodyMovable;
    private float _currentValue;

    public PlayerUnitMovementHandler(IUnitInput unitInput, IRigidbodyMovable rigidbodyMovable, PlayerMoveConfig config) : base(unitInput)
    {
        this.rigidbodyMovable = rigidbodyMovable;
        _currentValue = config.MoveSpeed;
    }

    public override void OnMoveUnitInputReceived(Vector3 value)
    {
        rigidbodyMovable.Rigidbody.velocity = new Vector3(value.x * rigidbodyMovable.Speed,
            rigidbodyMovable.Rigidbody.velocity.y, value.z * rigidbodyMovable.Speed);
        Debug.Log(_currentValue);
    }
}