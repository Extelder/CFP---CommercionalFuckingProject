using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IMoveUnitAnimatorInput
{
    public ReactiveProperty<bool> Moving { get; set; }
    public string MovingBoolName { get; set; }
}