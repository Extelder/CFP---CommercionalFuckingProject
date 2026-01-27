using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public interface IUpgradable<T>
{
    public ReactiveProperty<T> CurrentValue { get; set; }
    public void Upgrade(T value);
}
