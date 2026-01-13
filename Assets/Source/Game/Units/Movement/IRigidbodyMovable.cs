using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRigidbodyMovable : IUnitMovable
{
    public float Speed { get; set; }

    public Rigidbody Rigidbody { get; set; }
}