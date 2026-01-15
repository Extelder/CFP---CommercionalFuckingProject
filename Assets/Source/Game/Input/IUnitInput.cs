using System;
using UnityEngine;

public interface IUnitInput : IDisposable
{
    public event Action<Vector2> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;
}