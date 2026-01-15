using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitRotationHandler : UnitRotationHandler
{
    protected PlayerConfig config;

    public PlayerUnitRotationHandler(IUnitInput playerInput, IUnitTransformable unitTransformable, PlayerConfig config)
        : base(playerInput,
            unitTransformable)
    {
        this.config = config;
    }

    protected override void OnRotateInputReceived(Vector2 value)
    {
        float angle = Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg;
        if (angle == 0 || angle == 360)
            return;
        unitTransformable.Transform.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }
}