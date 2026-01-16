using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitMovementHandler : UnitMovementHandler
{
    protected IRigidbodyMovable rigidbodyMovable;

    public PlayerUnitMovementHandler(IUnitInput unitInput, IRigidbodyMovable rigidbodyMovable) : base(unitInput)
    {
        this.rigidbodyMovable = rigidbodyMovable;
    }

    public override void OnMovePlayerInputReceived(Vector2 value)
    {
        rigidbodyMovable.Rigidbody.velocity = new Vector3(value.x * rigidbodyMovable.Speed,
            rigidbodyMovable.Rigidbody.velocity.y, value.y * rigidbodyMovable.Speed);
    }
}