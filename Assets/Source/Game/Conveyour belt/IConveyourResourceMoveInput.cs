using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConveyourResourceMoveInput
{
    public Action<Vector3> MoveInputReceived { get; set; }
}