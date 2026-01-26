using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitMovementHandler : UnitMovementHandler, IPlayerMoveSpeedUpgradable
{
    protected IRigidbodyMovable rigidbodyMovable;
    private float _currentValue;

    public PlayerUnitMovementHandler(IUnitInput unitInput, IRigidbodyMovable rigidbodyMovable) : base(unitInput)
    {
        this.rigidbodyMovable = rigidbodyMovable;
    }

    public override void OnMoveUnitInputReceived(Vector3 value)
    {
        rigidbodyMovable.Rigidbody.velocity = new Vector3(value.x * rigidbodyMovable.Speed,
            rigidbodyMovable.Rigidbody.velocity.y, value.z * rigidbodyMovable.Speed);
        
        Debug.Log(CurrentValue);
    }


    public float CurrentValue { get; set; }

    public void Upgrade(float newValue)
    {
        CurrentValue = newValue;
    }
}