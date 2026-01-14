using System;
using UnityEngine;

public interface IPlayerInput : IDisposable
{
    public event Action<Vector2> MoveInputDrag;
}