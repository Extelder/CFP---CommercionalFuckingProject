using System;
using UnityEngine;

public interface IInput : IDisposable
{
    public event Action<Vector2> MoveInputDrag;
}