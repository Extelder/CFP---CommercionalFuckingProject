using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IUnitMovable
{
    ReactiveProperty<float> Speed { get; set; }
}