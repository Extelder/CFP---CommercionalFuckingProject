using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

[CreateAssetMenu(fileName = "ConveyorConfig", menuName = "Conveyor/ConveyorConfig")]
public class ConveyorBeltConfig : ScriptableObject, IConveyorSpeedUpgradable
{
    [field: SerializeField] public float MoveSpeed { get; set; }
    public ReactiveProperty<float> CurrentValue { get; set; }
    public void Upgrade(float value)
    {
        CurrentValue.Value = value;
        MoveSpeed = CurrentValue.Value;
    }
}
