using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerUnitMovementHandler : UnitMovementHandler
{
    protected IRigidbodyMovable rigidbodyMovable;
    
    public PlayerUnitMovementHandler(IUnitInput unitInput, IRigidbodyMovable rigidbodyMovable) : base(unitInput)
    {
        this.rigidbodyMovable = rigidbodyMovable;
    }

    public override void OnMoveUnitInputReceived(Vector3 value)
    {
        rigidbodyMovable.Rigidbody.velocity = new Vector3(value.x * rigidbodyMovable.Speed.Value,
            rigidbodyMovable.Rigidbody.velocity.y, value.z * rigidbodyMovable.Speed.Value);
    }
}