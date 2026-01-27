using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IRigidbodyMovable : IUnitMovable
{
    public ReactiveProperty<float> Speed { get; set; }

    public Rigidbody Rigidbody { get; set; }
}