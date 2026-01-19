using System;
using UnityEngine;

public interface IUnitInput : IDisposable
{
    public event Action<Vector3> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;
}