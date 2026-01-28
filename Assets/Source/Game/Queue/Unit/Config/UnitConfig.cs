using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitConfig", menuName = "Unit")]
public class UnitConfig : ScriptableObject, IUnitMoveSpeedUpgradable
{
    [field: SerializeField] public ReactiveProperty<float> Speed { get; private set; } = new ReactiveProperty<float>();
    [field: SerializeField] public uint NeededRecources { get; private set; }
    public ReactiveProperty<float> CurrentValue { get; set; }
    public void Upgrade(float value)
    {
        CurrentValue.Value = value;
        Speed.Value = CurrentValue.Value;
    }
}
